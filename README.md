# Web-API-Weather

!Hola! 

Esta aplicacion provee de ciertos endpoints que nos daran la informacion del clima en distintas ciudades y paises, y tambien nos dara informacion del clima en los proximos 5 dias. Cuenta con un LogIn para la autenticacion del usuario. Dentro de las tecnologias utilizadas tenemos .NET 6, EntityFramework, JWT, NUnit, SQLServer y Docker. Al proyecto entero lo realicé en un plazo de aproximadamente 4 dias. 

Al modelo de datos lo hice bastante simple, en primer lugar me hice un Diagrama en Draw.io para maquetar que posibles campos llevaran las tablas de la base de datos y que relaciones tenian entre ellas. Finalmente me decidi por hacer una tabla "Weather" la cual tiene los campos Id, Date (corresponde a la fecha de cuando se registra el clima), MaxTemperature y MinTemperature (corresponden a las temperaturas maximas y minimas que asumo que se registran en Celcius pues es la unidad de medida comun en Argentina), luego podemos observar los campos CityId y CountryId con sus respectivos CityName y CountryName (lo ideal seria que tanto las Ciudades como los Paises tengan sus propias tablas ya que lo mas probable es que querramos guardar mas informacion de esas entidades pero como el scope del proyecto no es muy grande decidi no complicarme tanto). Por otro lado, considero que no puede haber un CityId con igual id y con distinto CountryId, es decir las ciudades tendran siempre un id distinto sin importar que el pais sea otro.
Y por ultimo, tambien la tenemos a la tabla "User" que almacen un Id, Nombre, Email y Contraseña que servira para el LogIn de la aplicacion.
Todo esto fue creado a partir de las Migrations respetando "Code First".

En la aplicacion tenemos 3 endpoints. El primero se llama "GetWeatherByCountryAndCity" el cual recibe como parametros obligatorios el CityId y el CountryId. Esto se debe a que utilizando Ids y no Strings con los nombres de las ciudades, podremos buscar mas facilmente los registros deseados, dado que en otra situacion probablemente tengamos un Get para los registros de los Paises y sus Ciudades donde ahi seran otorgados los Ids para consultar en los demas endpoints. Soy consciente que podria haber hecho que reciba strings con los nombres de los paises, pasarlos a minuscula y ahi comparar con los nombres de la base de datos, pero me parecio mas seguro y de mejor calidad hacerlo de la manera en lo que lo hice.
Continuando, tambien recibe un parametro opcional booleano "isFarenheit" que en caso de que quieran saber el clima en unidad Fahrenheit lo envian en true y se hace la conversion de Celcius a Fahrenheit. El endpoint traera de la base de datos todos los registros cuyos CityId y CountryId coincidan con los enviados por la ruta.

Luego tenemos otro endpoint llamado "GetWeatherForNextFiveDaysByCity" que tambien recibira un CityId por parametro y una fecha que corresponde a la fecha a partir de la cual queremos saber sus climas en los proximos 5 dias. Tambien cuenta con la opcion de recibir el clima en Fahrenheit. 

Por ultimo tenemos el endpoint de "LogIn" que recibira un email y una contraseña para consultar en la base de datos si coincide con algun registro. En caso de que el login sea satisfactorio devolvera el Token de autenticacion (usando JWT) para utilizar en las consultas de los endpoint ya mencionados. En caso contrario, devolvera un mensaje informando que las crendenciales son invalidas.

La arquitectura de la aplicacion intenta separar todo lo posible la responsabilidad de cada parte. Empezando por los Controllers, donde de ahi viajaremos a los Interactors donde vamos a poder validar la informacion si fuese necesario, mapear los datos del modelo al DTO y es donde llamaremos al Service para obtener la informacion de la base de datos. Podemos observar que las interfaces de los DTO estan en su modulo aparte para luego ser implementados en la carpeta de DTO dentro de la Factory la cual sera la encargada de utilizar un Mapper que recibira una entidad del modelo y la implementacion de un DTO para asignar lo valores que querramos del modelo a cada campo del DTO. Podremos notar que tambien cree una carpeta de Validators, lo ideal seria validar los datos de entrada si fuese necesario antes de ir al Service. 

Todo esto funciona a traves de la Inyeccion de Dependencias que se puede ver en los constructores de cada clase.

Siguiendo, tambien podemos ver que tenemos un proyecto dedicado a los testing unitarios. Fue lo primero que implemente dado que ya tenia todo especificado, aunque luego hice modificaciones en el comportamiento de la aplicacion asi que se fueron agregando mas tests, por consiguiente aplique TDD ya que creaba tests e implementaba en simultaneo. La libreria utilizada es NUnit. 

Cabe destacar que la aplicacion entera y su base de datos esta en un contenedor, pero es la primera vez que utilizo Docker y lo aprendi en pocos dias. Entiendo que para levantar la aplicacion, nos descargamos el proyecto entero y elegimos Docker Compose para iniciarlo.




