Para acceder a la interfaz de "admin" solo es necesario correr la solución que se encuentra en la carpeta raiz.
Esta solución ejecuta el WebAPI y el MVC al mismo tiempo.

Para acceder a la interfaz de "guest" se requiere tener iniciado el proyecto antes mencionado y ejecutar el archivo index.html 
que se encuentra en la carpeta "Angular".

Admin(MVC):
	En cuanto se abre la pagina web al iniciar el proyecto se podrá ver la lista de Surveys que se encuentran en la base
	de datos. 
	Arriba de la lista de surveys se puede observar un recuadro que nos permite ingresar el titulo y descripcion de una
	survey y crearla al hacer click en el boton "Save".
	A la derecha de cada survey hay tres botones, 
		El primero es para realizar modificaciones a la survey.
		El segundo es para agregar/eliminar questions de dicha survey.
		El tercero es para eliminar la survey.
	En la barra superior se puede ver un boton de Home y Report, el botón de Home te lleva a la pantalla de Surveys descrita
	anteriormente, mientras que el botón "Report" te lleva a una vista donde se encuentra los reportes de las Surveys completadas
	que califiquen para generar un reporte.

Guest(AngularJS)
	En cuanto se abre la pagina web al iniciar en index se podrá ver la lista de Surveys que se encuentran en la base
	de datos disponibles para un guest. 
	Al hacer click en el título de una survey se podrá ir a una pantalla donde se desplegarán las preguntas con sus opciones
	para ser contestadas por el usuario.
	
	Comentarios: Esta parte deja mucho que desear visualmente debido a que no se hizo un archivo .css el cual tenía planeado
		     desarrollar tras terminar el método de Post para las answers.
		     Pude guardar todas las respuestas en un array para ser enviado al WebAPI, pero el método para enviar este array
		     me daba error provocando que el controlador de answers ya no estuviera definido.
		     Este ultimo día no pude resolver este problema y dejé comentado dicho método. 
		     Algo que estaba planeando hacer era mover ese método a otro controlador que no estuviera dentro de una IIFE y llamarlo allá.
	En resumen: Falto crear el .css y arreglar el método de Post para las answers.
	
	
	