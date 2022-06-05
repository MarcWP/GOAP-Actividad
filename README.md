# GOAP
Proyecto de inteligencia artificial mediante GOAP para la asignatura Inteligencia Artificial en Videojuegos.

### Características generales del proyecto

* Inteligencia artificial manejada por GOAP (Goal Oriented Action Planning).

* Tres entidades que interactuan entre sí utilizando este sistema.

* Pequeña escena "City" bajo "Assets/CarCity" de una ciudad donde el usuario puede observar a las entidades y jugar con ellas.

### Entidades

* Entidad Coche (5 acciones): Sus objetivos son volver a casa después de trabajar, tener el depósito lleno y ser libres en caso de que cometan un crimen. Pululan por la ciudad entre sus hogares y su lugar de trabajo. :
  * GoToWork:.
** ReturnHome:.
** WaitForRemolque(lo se, debería ser ReturnForTow o algo):.
** GoToGasStation:.
** GoToPrison:.



* Entidad Remolque (3 acciones): Su objetivo es esperar a que los coches se queden sin gasolina para recogerlos y trasladarlos a la gasolinera, donde regeneran el gas. Sus acciones son:
GoToCar(se traslada hasta el coche).
BringBrokenCarToGasStation: llevar el coche rescatado a la estación de servicio para que recupere gasolina.
ReturnToRepairShop: volver al puesto de guardia

* Entidad Coche de policia (3 acciones): 
GetSpeedingCar:.
FollowSpeederToPrison:.
ReturnToPolicePost:.

### Modificaciones a la base GOAP

### Acerca del juego
La escena consta de 4 elementos fundamentales: la ciudad, las entidades, el panel de balance y el panel de mejoras. Las entidades se mueven por la ciudad y realizan sus acciones. Algunas de estas acciones conllevan costes o ingresos en
