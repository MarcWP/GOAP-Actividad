# GOAP
Proyecto de inteligencia artificial mediante GOAP para la asignatura Inteligencia Artificial en Videojuegos.

### Características generales del proyecto
* Inteligencia artificial manejada por GOAP (Goal Oriented Action Planning).
* Tres entidades que interactuan entre sí utilizando este sistema.
* Pequeña escena "City" bajo "Assets/CarCity" de una ciudad donde el usuario puede observar a las entidades y jugar con ellas.

### Entidades
* Entidad Coche (entidades blancas): Sus objetivos son volver a casa después de trabajar, tener el depósito lleno y ser libres en caso de que cometan un crimen. Pululan por la ciudad entre sus hogares y su lugar de trabajo. Necesitan gas para moverse, y si se quedan sin paciencia se pasarán del límite de velocidad:
  * GoToWork: la entidad se dirige al trabajo, agregando dinero al balance.
  * ReturnHome: la entidad vuelve al hogar.
  * WaitForRemolque(lo se, debería ser ReturnForTow o algo): si la entidad no tiene gas, se queda quieta y espera a que venga el remolque.
  * GoToGasStation: La entidad es "remolcada" a la estación de servicio.
  * GoToPrison: la entidad es "arrestada" por el coche de policía y se dirige a su celda.

* Entidad Remolque (entidades verdes): Su objetivo es esperar a que los coches se queden sin gasolina para recogerlos y trasladarlos a la gasolinera, donde regeneran el gas. Sus acciones son:
  * GoToCar: se traslada hasta el coche sin gasolina, que en estos momentos estaría quieto.
  * BringBrokenCarToGasStation: llevar el coche rescatado a la estación de servicio para que recupere gasolina.
  * ReturnToRepairShop: volver al puesto de guardia

* Entidad Coche de policia (entidades azules): Su objetivo es esperar a los coches que pierden la paciencia y se pasan del límite de velocidad. Luego los detiene y los traslada a comisaría, donde pagan multa y pasan condena. Las celdas de prisión funcionan mediante inventario. La celda objetivo se traslada y comunica a las entidades y si no hay ninguna disponible, no será posible realizar la acción.
  * GetSpeedingCar: se traslada hasta el coche que se ha pasado del límite de velocidad, que en estos momentos se está moviendo.
  * FollowSpeederToPrison: sigue al criminal a prisión donde se le asigna una celda.
  * ReturnToPolicePost: tras llevar al prisionero a su celda, el coche de policía vuvelve a la estación de guardia.

### Modificaciones a la base GOAP
* Agregada condición follow. Si es verdadera, las entidades actualizan la posición objetivo en cada frame hasta llegar a esta.
* Agregado método para abortar una acción previo a completarla.
* Abortar las acciones que se están ejecutando en ese momento y cesar el movimiento si el coche se queda sin gasolina.
* Abortar las acciones que se están ejecutando en ese momento y aumentar la velocidad si el coche pierde la paciencia.

### Acerca del juego
La escena consta de 4 elementos fundamentales: la ciudad, las entidades, el panel de balance y el panel de mejoras. Las entidades se mueven por la ciudad y realizan sus acciones. Algunas de estas acciones conllevan costes o ingresos, que modifican el balance total de la partida (panel inferior izquierdo en la escena). Podemos optar a mejoras mediante el panel de mejoras (panel superior derecho en la escena). Para poder comprar mejoras nuestro balance deberá ser superior al coste listado por cada mejora.
