Para acceder a la interfaz de "admin" solo es necesario correr la soluci�n que se encuentra en la carpeta raiz.
Esta soluci�n ejecuta el WebAPI y el MVC al mismo tiempo.

Para acceder a la interfaz de "guest" se requiere tener iniciado el proyecto antes mencionado y ejecutar el archivo index.html 
que se encuentra en la carpeta "Angular".

Admin(MVC):
	En cuanto se abre la pagina web al iniciar el proyecto se podr� ver la lista de Surveys que se encuentran en la base
	de datos. 
	Arriba de la lista de surveys se puede observar un recuadro que nos permite ingresar el titulo y descripcion de una
	survey y crearla al hacer click en el boton "Save".
	A la derecha de cada survey hay tres botones, 
		El primero es para realizar modificaciones a la survey.
		El segundo es para agregar/eliminar questions de dicha survey.
		El tercero es para eliminar la survey.
	En la barra superior se puede ver un boton de Home y Report, el bot�n de Home te lleva a la pantalla de Surveys descrita
	anteriormente, mientras que el bot�n "Report" te lleva a una vista donde se encuentra los reportes de las Surveys completadas
	que califiquen para generar un reporte.

Guest(AngularJS)
	En cuanto se abre la pagina web al iniciar en index se podr� ver la lista de Surveys que se encuentran en la base
	de datos disponibles para un guest. 
	Al hacer click en el t�tulo de una survey se podr� ir a una pantalla donde se desplegar�n las preguntas con sus opciones
	para ser contestadas por el usuario.
	
	Comentarios: Esta parte deja mucho que desear visualmente debido a que no se hizo un archivo .css el cual ten�a planeado
		     desarrollar tras terminar el m�todo de Post para las answers.
		     Pude guardar todas las respuestas en un array para ser enviado al WebAPI, pero el m�todo para enviar este array
		     me daba error provocando que el controlador de answers ya no estuviera definido.
		     Este ultimo d�a no pude resolver este problema y dej� comentado dicho m�todo. 
		     Algo que estaba planeando hacer era mover ese m�todo a otro controlador que no estuviera dentro de una IIFE y llamarlo all�.
	En resumen: Falto crear el .css y arreglar el m�todo de Post para las answers.
	
	
	