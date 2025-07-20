# TowerDefense-RicardCabezas

## Architecture
The architecture has been chosen to have a code base easy to scale and to be able to work with many people, all without losing performance. But, also having
in mind some obvious limitations caused by the amount of time that was stipulated to complete the project.

It's heavily inspirated in the [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).
It is indeed a little bit more simple but it follows the same structure. Now I'll briefly enumate some of thebenefits that made me choose it:

- Highly deployed from the engine. It's not likely that a game will change the engine but it make less traumatic to change some key systems
in a project like substituting Addressables instead of regular Asset Bundles. This is possible because the game logic won't depend on those specifics.

- Allows to create unit tests easier since the logic is quite isolated.

- Allows your code base to be agnostic of where your data comes from (server, local, etc)

- It enforces the features to be decoupled from each other since the logic is encapsulated in small blocks instead of big directors that has a lot of
reponsability.

Obviously, it also has some cons that need to be taken in to account:

- As everything is quite decoupled, sometimes is less easy to follow the execution order

- It adds some boilerplate since the architecture needs to follow a clear structure, which on the other hand can be useful for big teams to make sure the
codebase keeps uniformed.

- It's not super fast to create new features so it's usually bad for prototyping.

-------------------------------

Now let's take a look on how the it works in this project

### Enitity
It's the most basic data form, it usually contains the "model" of the objects. For instance,  `CreepEntity`
is the basic data representation of a Creep. So, it will contain it's health, speed, etc.

### Repository
This classes are the layer that communicates with the logic of the game and it's in charge of create and retrieve
the data. So it will be in charge of looking in the configs, accessing the database, pools, etc

### UseCase
This clases wrap something that happens in the game and contains the logic inside. They should be small
since in theory the will tackle a specific scenario, rather than grouping a lot of logic. If so, they can be 
concatenated (use case calls another use case). They get the data from the Repositories. They can be called from the controllers. They don't know about the views or controllers.

### Controller
This clases are in charge of starting the flow of the logic. They listen for the user inputs to call a specific use case. They can know the views since the must listen from them sometimes (buttons)

### Presenters
They just listen for global events in order to update the views. They are not attached to any other class rather than the view. They shouldn't contain any logic rather than transforming raw data to be represented by the view.

### Views
Just plane Monobehaviours with the needed components that will be updated referenced.

### Installer
They are the entry point of the code, they are in charge of create all the clases mentioned previously and distribute the dependencies. Also, the `GameInstaller` is the one that starts the game.

-------------------------------

Summarizing, the regular flow for for a feature would be:


```
Installer creates the repository, use cases and controllers --> The repository creates the entities, views and presenters

The controller registers an input and calls the use case --> The use case does some logic and outputs the changes in a global event --> Any presenter listening updates the view --> Any controller listening reacts to start a new logic flow
```


-------------------------------


Some other parts of the sample I'll like to mention:

##### `PoolService`
Since the game has some objects that will be constantly being spawned and destroyed it must implement some type of pooling, this is what this service does. It's used to pool creeps and projectiles but potentially could pool any other object in the game.
Since the architecture makesmandatory to have a presenter and potentially a controller it made sense to also pool those two clases, to avoid creating them every time. The Entity could also be pooled but this was not made for a lack of time. So, the pool is indeed pooling a generic class that contains all those elements, and each one of them will be resposible of casting them to the specifics:  [CreepGameRepresentation](Assets/Scripts/Core/Creeps/Views/CreepGameRepresentation.cs)


##### `ProjectileFactory`
One of the requisits was to add a different behaviour in one of the turrets and make it easy to add new behaviours.
 I decided to put that behaviour in the projectile instead of the turret to be able to mix the turrets with their behaviours independently 
from the views. This factory receives the specific configuration and decides what view, presenter and controller have to create. 
That controller contains some specific uses cases, which means that adding new behaviours is as easy as creating a new config that inherits from 
the generic one, create the specific views, presenter and controller that will contain the new logic. And, finally add it as an option in the
 factory. So nothing needs to be modified, just add new things.

Creeps asume they will always have the same behaviour but this was made for the lack of time, they should be implemented the same way, with a factor 
that decides which creep is and what behaviour it is affected by (moving, flying, etc)


##### Dependencies
When I started the project I added the plugin Extenject since I believe that it makes a lot of sense in this kind of architectures where everything is decoupled and you end up having that many clases (it also helps with the testing). It helps reducing the verbose of the constructors and has a lot of helpful features as any other DI implementation. On the other hand, it also comes with some initial loading cost and it adds a lot of complexity on the setup. So, for production I would have use it, but I avoided it here because of the limited time. So, the project has some direct injection through the constructor but also has a ServiceLocator class helper. Again, in production I'd drop this in favor of a more elaborated DI tool.
