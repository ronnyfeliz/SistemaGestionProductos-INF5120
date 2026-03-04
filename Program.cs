//Ronny Feliz 100704427 INF5120-3 03/03/2026

using System.IO;
using System.Linq;

class Almacen {

    private int ID;
    private string nombre;
    private string marca;
    private double precio;
    private int cantidad;

    //LISTA DINAMICA PARA GUARDAR LOS PRODUCT
    public List<Almacen> productos = new List<Almacen>();
    public string rutaArchivo = "productos.txt";

    //METODOS GETTER Y SETTER PARA EL ACCESO A LAS VARIABLES PRIVADAS DE LA CLASE PRINCIPAL ALMACEN
    public int GetID() { return ID; }
    public void SetID(int id) { ID = id; }

    public string GetNombre() { return nombre; }
    public void SetNombre(string nom) { nombre = nom; }

    public string GetMarca() { return marca; }
    public void SetMarca(string m) { marca = m; }

    public double GetPrecio() { return precio; }
    public void SetPrecio(double p) { precio = p; }

    public int GetCantidad() { return cantidad; }
    public void SetCantidad(int c) { cantidad = c; }

    public void GuardarProducto(List<Almacen> productos, string rutaArchivo)
    {
        using (StreamWriter sw = new StreamWriter(rutaArchivo))
        {
            foreach (var p in productos)
            {
                sw.WriteLine($"{p.GetID()};{p.GetNombre()};{p.GetMarca()};{p.GetPrecio()};{p.GetCantidad()}");
            }
        }
    }

    public bool VolverRegistrarProducto()
    {
        string repetir;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nDESEA VOLVER A REGISTRAR OTRO PRODUCTO? (SI/NO): ");
            Console.ResetColor();

            repetir = Console.ReadLine().Trim().ToLower();

            if (repetir == "si")
            {
                Console.Clear(); 
                return true;     
            }
            else if (repetir == "no")
            {
                return false; 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEBE INGRESAR 'SI' O 'NO'.");
                Console.ResetColor();
            }
        }
    }    
    public void Menu() {

        int respuesta;

        do
        {

            Console.Clear();
            Console.Title = "Sistema de Almacén";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("________________________________________");
            Console.WriteLine("         SISTEMA DE ALMACÉN             ");
            Console.WriteLine("________________________________________");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSELECCIONE UNA OPCION:\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.AGREGAR PRODUCTO");
            Console.WriteLine("2.BUSCAR PRODUCTO");
            Console.WriteLine("3.ELIMINAR PRODUCTO");
            Console.WriteLine("4.LISTAR PRODUCTO");
            Console.WriteLine("5.ACTUALIZAR PRODUCTO");
            Console.WriteLine("6.SALIR DEL SISTEMA");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("________________________________________");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nELIJA UNA OPCION: ");
            Console.ResetColor();

            //VALIDACION PARA LA VARIABLE RESPUESTA
            if (int.TryParse(Console.ReadLine(), out respuesta))
            {
                switch (respuesta)
                {
                    case 1:
                        RegistrarProducto(productos);
                        break;

                    case 2:
                        BuscarProducto();
                        break;

                    case 3:
                        EliminarProducto();
                        break;

                    case 4:
                        ListarProductos();
                        break;

                    case 5:
                        ActualizarProducto();
                        break;

                    case 6:
                        GuardandoProductos();
                        Thread.Sleep(1500);
                        GuardarProducto(productos, "productos.txt");
                        Salir();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOPCION NO VALIDA.");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDEBE INGRESAR UN NUMERO VALIDO.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPRESIONE CUALQUIER TECLA PARA CONTINUAR...");
            Console.ResetColor();
            Console.ReadKey();

        } while (respuesta != 6);

    }

    public void Salir()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("SALIENDO DEL SISTEMA");
        Console.ResetColor();

        for (int ciclo = 0; ciclo < 3; ciclo++)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(".");
                Console.ResetColor();
                Thread.Sleep(500);
            }

            Thread.Sleep(500);
            Console.Write("\b\b\b   \b\b\b");
            Thread.Sleep(500);
        }

        Console.WriteLine("\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ");
        Console.WriteLine("SALIDA DEL SISTEMA EXITOSA.");
        Console.ResetColor();

        Creditos();

        Console.Clear();

    }


    public void Creditos()
    {

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("===============================================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("          TODOS LOS DERECHOS RESERVADOS 2026");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                  CREACIÓN: 03/03/2026");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("                     VERSIÓN: 1.0v");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("               ACTUALIZACIÓN: 03/03/2026");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("                   DISEÑO: RONNY FELIZ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("===============================================");
        Console.ResetColor();
        Console.ReadKey();

    }


    public void RegistrarProducto(List<Almacen> productos)
    {
        int ID;
        string nombre;
        string marca;
        double precio;
        int cantidad;
        string confirmacion;

        do {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("REGISTRAR PRODUCTO");
            Console.WriteLine("________________________________________");
            Console.ResetColor();

            //VALIDACIONES PARA LOS ATRIBUTOS DEL PRODUCTO
            while (true)
            {
                Console.Write("INGRESE EL ID: ");
                if (int.TryParse(Console.ReadLine(), out ID) && ID > 0)
                {
                    //VALIDACION PARA EVITAR DUPLICADOS EN EL ARCHIVO DE TEXTO
                    bool existe = productos.Any(p => p.ID == ID);
                    if (!existe)
                    break;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: YA EXISTE UN PRODUCTO CON ESTE ID.");
                    Console.ResetColor();
                }
                else { 

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ID INVALIDO. DEBE SER UN NUMERO ENTERO POSITIVO.");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.Write("INGRESE EL NOMBRE: ");
                nombre = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(nombre))
                {
                    Console.Write("INGRESE LA MARCA: ");
                    marca = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(marca))
                    {
                        bool existe = productos.Any(p => p.nombre.ToLower() == nombre.ToLower() && p.marca.ToLower() == marca.ToLower());
                        if (!existe)
                            break;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: YA EXISTE UN PRODUCTO CON ESTE NOMBRE Y MARCA.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("LA MARCA NO PUEDE ESTAR VACIA.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("EL NOMBRE NO PUEDE ESTAR VACIO.");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.Write("INGRESE EL PRECIO: ");
                if (double.TryParse(Console.ReadLine(), out precio) && precio > 0)
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PRECIO INVALIDO. DEBE SER UN PRECIO POSITIVO.");
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("INGRESE LA CANTIDAD: ");
                if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CANTIDAD INVALIDA. DEBE SER POSITIVO Y MAYOR A CERO.");
                Console.ResetColor();
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("________________________________________");
                Console.ResetColor();
                Console.Write("ESTA SEGURO? (SI/NO): ");
                confirmacion = Console.ReadLine().Trim().ToLower();
                if (confirmacion == "si" || confirmacion == "no")
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEBE INGRESAR 'SI' o 'NO'.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("NO SE ACEPTAN OTRAS RESPUESTAS QUE NO SEAN ESAS.");
                Console.ResetColor();
            }

            if (confirmacion == "si")
            {
                // SE CREA EL OBJETO Y AGREGAR A LA LISTA
                Almacen producto = new Almacen()
                {
                    ID = ID,
                    nombre = nombre,
                    marca = marca,
                    precio = precio,
                    cantidad = cantidad
                };

                productos.Add(producto);
                GuardarProducto(productos, "productos.txt");

                // ANIMACION DE LOADING USANDO BUCLE FOR Y THREAD.SLEEP
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("________________________________________");
                Console.Write("REGISTRANDO PRODUCTO");
                Console.ResetColor();

                for (int ciclo = 0; ciclo < 3; ciclo++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".");
                        Console.ResetColor();
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(500);
                    Console.Write("\b\b\b   \b\b\b");
                    Thread.Sleep(500);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPRODUCTO REGISTRADO CORRECTAMENTE.");
                Console.ResetColor();
            }
            else
            {
                // ANIMACION DE LOADING USANDO BUCLE FOR Y THREAD.SLEEP
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("________________________________________");
                Console.Write("CANCELANDO REGISTRO");
                Console.ResetColor();

                for (int ciclo = 0; ciclo < 3; ciclo++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(".");
                        Console.ResetColor();
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(500);
                    Console.Write("\b\b\b   \b\b\b");
                    Thread.Sleep(500);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nREGISTRO CANCELADO.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ");
                Console.WriteLine("VUELVA A INTRODUCIR LOS DATOS..");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.ResetColor();
            Console.ReadKey();

        } while (VolverRegistrarProducto());
    }

    public void GuardandoProductos()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ");
        Console.Write("GUARDANDO PRODUCTOS");
        Console.ResetColor();

        for (int ciclo = 0; ciclo < 3; ciclo++)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(".");
                Console.ResetColor();
                Thread.Sleep(500);
            }
            Thread.Sleep(500);
            Console.Write("\b\b\b   \b\b\b");
            Thread.Sleep(500);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ");
        Console.WriteLine("\nPRODUCTOS GUARDADOS CORRECTAMENTE.");
        Console.ResetColor();
    }

    //FUNCION PARA CARGAR EL ARCHIVO DONDE SE GUARDAN LOS PRODUCTOS
    public void CargarProductos(List<Almacen> productos, string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
            return;

        productos.Clear();

        using (StreamReader sr = new StreamReader(rutaArchivo))
        {
            string linea;
            while ((linea = sr.ReadLine()) != null)
            {
                string[] datos = linea.Split(';');
                if (datos.Length == 5) 
                {
                    Almacen p = new Almacen()
                    {
                        ID = int.Parse(datos[0]),
                        nombre = datos[1],
                        marca = datos[2],
                        precio = double.Parse(datos[3]),
                        cantidad = int.Parse(datos[4])
                    };
                    productos.Add(p);
                }
            }
        }
    }

    public void BuscarProducto()
    {
        string respuestaBuscar;

        do
        {
            Console.Clear();
            int parametro;

            // MENU PARA ELEGIR EL PARAMETRO DEL PRODUCTO A BUSCAR
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("BUSCAR PRODUCTO");
                Console.WriteLine("________________________________________");
                Console.ResetColor();

                

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ELIJA UN PARAMETRO");
                Console.WriteLine(" ");
                Console.WriteLine("1.ID");
                Console.WriteLine("2.NOMBRE");
                Console.WriteLine("3.MARCA");
                Console.WriteLine("4.PRECIO");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("________________________________________");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out parametro) && parametro >= 1 && parametro <= 4)
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OPCION INVALIDA, DEBE INGRESAR UN NUMERO DEL 1 AL 4.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();

            }

            // BUSCA EL PRODUCTO SEGUN EL PARAMETRO DESEADO
            List<Almacen> encontrados = new List<Almacen>();

switch (parametro)
            {
        case 1: //ID
              int idBuscado;

              while (true)
                    {
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine(" ");
              Console.Write("INGRESE EL ID DEL PRODUCTO: ");
              Console.ResetColor();

              if (int.TryParse(Console.ReadLine(), out idBuscado))
              break;

              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("ERROR: DEBE INGRESAR UN NUMERO VALIDO.");
              Console.ResetColor();

              Console.ForegroundColor = ConsoleColor.DarkGray;
              Console.WriteLine("PRESIONE CUALQUIER TECLA PARA INTENTAR DE NUEVO...");
              Console.ResetColor();

              Console.ReadKey();
              Console.Clear();

              Console.ForegroundColor = ConsoleColor.Cyan;
              Console.WriteLine("BUSCAR PRODUCTO");
              Console.WriteLine("________________________________________");
              Console.ResetColor();
              }

              encontrados = productos.FindAll(p => p.GetID() == idBuscado);
              break;

                case 2: // NOMBRE
                    Console.Write("INGRESE EL NOMBRE DEL PRODUCTO: ");
                    string nombreBuscado = Console.ReadLine().Trim().ToLower();
                    encontrados = productos.FindAll(p => p.GetNombre().ToLower() == nombreBuscado);
                    break;

                case 3: // MARCA
                    Console.Write("INGRESE LA MARCA DEL PRODUCTO: ");
                    string marcaBuscado = Console.ReadLine().Trim().ToLower();
                    encontrados = productos.FindAll(p => p.GetMarca().ToLower() == marcaBuscado);
                    break;

                case 4: // PRECIO
                    double precioBuscado;

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("INGRESE EL PRECIO DEL PRODUCTO: ");
                        Console.ResetColor();

                        if (double.TryParse(Console.ReadLine(), out precioBuscado))
                        {
                            if (precioBuscado > 0)
                                break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: EL PRECIO NO PUEDE SER NEGATIVO.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: DEBE INGRESAR UN NUMERO VALIDO.");
                            Console.ResetColor();
                        }

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("PRESIONE CUALQUIER TECLA PARA INTENTAR DE NUEVO...");
                        Console.ResetColor();

                        Console.ReadKey();
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("BUSCAR PRODUCTO");
                        Console.WriteLine("________________________________________");
                        Console.ResetColor();
                    }

                    encontrados = productos.FindAll(p =>
                        Math.Abs(p.GetPrecio() - precioBuscado) < 0.01);

                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ");
            Console.Write("BUSCANDO PRODUCTOS");
            Console.ResetColor();

            for (int ciclo = 0; ciclo < 3; ciclo++)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(".");
                    Console.ResetColor();
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);
                Console.Write("\b\b\b   \b\b\b");
                Thread.Sleep(500);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBUSQUEDA FINALIZADA.");
            Console.ResetColor();

            //MOSTRAR RESULTADOS EN PANTALLA MEDIANTE LA VARIABLE ENCONTRADOS
            if (encontrados.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPRODUCTOS ENCONTRADOS: {encontrados.Count}");
                Console.WriteLine(" ");
                Console.ResetColor();
                foreach (var p in encontrados)
                {
                    Console.WriteLine($"ID: {p.GetID()} | NOMBRE: {p.GetNombre()} | MARCA: {p.GetMarca()} | PRECIO: {p.GetPrecio()}RD$ | CANTIDAD: {p.GetCantidad()}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNO SE ENCONTRÓ NINGÚN PRODUCTO CON ESE CRITERIO.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nDESEA REALIZAR OTRA BUSQUEDA? (SI/NO): ");
            Console.ResetColor();
            respuestaBuscar = Console.ReadLine().Trim().ToLower();

        } while (respuestaBuscar == "si");
    }

    public void ListarProductos()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("LISTADO DE TODOS LOS PRODUCTOS");
        Console.WriteLine("-------------------------------");
        Console.ResetColor();

        if (productos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NO HAY PRODUCTOS REGISTRADOS.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"{"ID",-10} {"NOMBRE",-20} {"MARCA",-15} {"PRECIO",10} {"CANT.",8}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (var p in productos)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(
                    $"{p.GetID(),-10:D4}" +
                    $"{p.GetNombre(),-20} " +
                    $"{p.GetMarca(),-15} " +
                    $"{p.GetPrecio(),8}RD$ " +
                    $"{p.GetCantidad(),7}"
                );

                Console.ResetColor();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
public void EliminarProducto()
    {
string respuestaEliminar;

do
   {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("ELIMINAR PRODUCTO");
    Console.WriteLine("________________________________________");
    Console.ResetColor();

    int idEliminar;

    while (true)
            {
    Console.Write("INGRESE EL ID DEL PRODUCTO: ");
    if (int.TryParse(Console.ReadLine(), out idEliminar) && idEliminar > 0)
    break;

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("ID INVALIDO. DEBE SER UN NUMERO ENTERO POSITIVO.");
    Console.ResetColor();
    }

    var encontrados = productos.FindAll(p => p.GetID() == idEliminar);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("");
    Console.Write("BUSCANDO PRODUCTO");
    Console.ResetColor();
    for (int ciclo = 0; ciclo < 3; ciclo++)
     {
       for (int i = 0; i < 3; i++)
                {
       Console.ForegroundColor = ConsoleColor.Green;
       Console.Write(".");
       Console.ResetColor();
       Thread.Sleep(500);
        }
         Thread.Sleep(500);
         Console.Write("\b\b\b   \b\b\b");
         Thread.Sleep(500);
         }

         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("\nBUSQUEDA FINALIZADA.");
         Console.ResetColor();

         if (encontrados.Count > 0)
            {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine($"\nPRODUCTO ENCONTRADO:");
         Console.WriteLine();
         Console.ResetColor();
         
         foreach (var p in encontrados)
          {

         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine($"ID: {p.GetID()} | NOMBRE: {p.GetNombre()} | MARCA: {p.GetMarca()} | PRECIO: {p.GetPrecio()}RD$ | CANTIDAD: {p.GetCantidad()}");
         Console.ResetColor();
         }

         while (true)
                {
         
         Console.Write("\nDESEA ELIMINAR ESTE PRODUCTO? (SI/NO): ");
         respuestaEliminar = Console.ReadLine().Trim().ToLower();
         
         if (respuestaEliminar == "si" || respuestaEliminar == "no")
         break;

         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("DEBE INGRESAR 'SI' O 'NO'.");
         Console.ResetColor();
         }

         if (respuestaEliminar == "si")
          {
         string confirmacionSegura;

         while (true)
             {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.Write("ESTA SEGURO? (SI/NO): ");
         Console.ResetColor();
         confirmacionSegura = Console.ReadLine().Trim().ToLower();

         if (confirmacionSegura == "si" || confirmacionSegura == "no")
         break;

         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("DEBE INGRESAR 'SI' O 'NO'.");
         Console.ResetColor();
         }

         if (confirmacionSegura == "si")
          {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine(" ");
         Console.Write("ELIMINANDO PRODUCTO");
         Console.ResetColor();

         for (int ciclo = 0; ciclo < 3; ciclo++)
         {
          for (int i = 0; i < 3; i++)
           {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.Write(".");
         Console.ResetColor();
         Thread.Sleep(500);
          }
         Thread.Sleep(500);
         Console.Write("\b\b\b   \b\b\b");
         Thread.Sleep(500);
         }

         foreach (var p in encontrados)
         productos.Remove(p);

         GuardarProducto(productos, rutaArchivo);

         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine(" ");
         Console.WriteLine("\nPRODUCTO ELIMINADO CORRECTAMENTE.");
         Console.ResetColor();
         }
                    
         else
             {
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\nELIMINACIÓN CANCELADA.");
               Console.ResetColor();
               }
             }
                
         else
             {
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("\nELIMINACIÓN CANCELADA.");
              Console.ResetColor();
              }
            }
            
            else
            
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNO SE ENCONTRÓ NINGÚN PRODUCTO CON ESE ID.");
            Console.ResetColor();
            }

            while (true)
            {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nDESEA ELIMINAR OTRO PRODUCTO? (SI/NO): ");
            Console.ResetColor();
            respuestaEliminar = Console.ReadLine().Trim().ToLower();

            if (respuestaEliminar == "si" || respuestaEliminar == "no")
            break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DEBE INGRESAR 'SI' O 'NO'.");
            Console.ResetColor();

            }

        } while (respuestaEliminar == "si");
    }

public void ActualizarProducto()
{
string repetir;

do
        {

Console.Clear();
int idUpdate;

 
while (true)
{

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("ACTUALIZACION DE PRODUCTO");
Console.WriteLine("_______________________________________________");
Console.ResetColor();
Console.Write("INGRESE EL ID DEL PRODUCTO: ");
               
if (int.TryParse(Console.ReadLine(), out idUpdate) && idUpdate > 0)
break;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(" ");
Console.WriteLine("ID INVALIDO. DEBE SER UN NUMERO ENTERO POSITIVO.");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine(" ");
Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR...");
Console.ResetColor();

Console.ReadKey();

            }

var producto = productos.Find(p => p.GetID() == idUpdate);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" ");
Console.Write("BUSCANDO PRODUCTO");
Console.ResetColor();

for (int ciclo = 0; ciclo < 3; ciclo++)

 {

for (int i = 0; i < 3; i++)
  {
                    
Console.ForegroundColor = ConsoleColor.Green;
Console.Write(".");
Console.ResetColor();
Thread.Sleep(400);
 
                     } 
Thread.Sleep(400);
Console.Write("\b\b\b   \b\b\b");
                            }

Console.WriteLine("\n");

if (producto != null)
            {
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("PRODUCTO ENCONTRADO:");
Console.WriteLine(" ");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("_______________________________________________");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"ID: {producto.GetID()}");
Console.WriteLine($"NOMBRE: {producto.GetNombre()}");
Console.WriteLine($"MARCA: {producto.GetMarca()}");
Console.WriteLine($"PRECIO: {producto.GetPrecio()}RD$");
Console.WriteLine($"CANTIDAD: {producto.GetCantidad()}");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("_______________________________________________");
Console.WriteLine("\nINGRESE LOS NUEVOS DATOS");
Console.WriteLine("(DEJE VACIO Y PRESIONE ENTER PARA NO MODIFICAR)");
Console.ResetColor();

//DATOS NUEVOS
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("_______________________________________________");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(" ");
Console.Write("NUEVO NOMBRE: ");
Console.ResetColor();
string nuevoNombre = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(nuevoNombre))
producto.SetNombre(nuevoNombre.Trim());

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("NUEVA MARCA: ");
Console.ResetColor();
string nuevaMarca = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(nuevaMarca))
producto.SetMarca(nuevaMarca.Trim());

while (true)
     {
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("NUEVO PRECIO: ");
Console.ResetColor();
string entradaPrecio = Console.ReadLine();

if (string.IsNullOrWhiteSpace(entradaPrecio))
break;

if (double.TryParse(entradaPrecio, out double nuevoPrecio) && nuevoPrecio > 0)
  {
producto.SetPrecio(nuevoPrecio);
break;
  }

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("PRECIO INVALIDO.");
Console.ResetColor();
}

while (true)
    {
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("NUEVA CANTIDAD: ");
Console.ResetColor();
string entradaCantidad = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("_______________________________________________");
Console.ResetColor();

if (string.IsNullOrWhiteSpace(entradaCantidad))
break;

if (int.TryParse(entradaCantidad, out int nuevaCantidad) && nuevaCantidad > 0)
 {
producto.SetCantidad(nuevaCantidad);
break;
}

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("CANTIDAD INVALIDA.");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.ResetColor();
                }

 
string confirmarCambios;
while (true)
   
                {
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("\nDESEA GUARDAR LOS CAMBIOS? (SI/NO): ");
Console.ResetColor();
confirmarCambios = Console.ReadLine().Trim().ToLower();
if (confirmarCambios == "si" || confirmarCambios == "no")
break;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("DEBE INGRESAR 'SI' O 'NO'.");
Console.ResetColor();
     }

if (confirmarCambios == "si")
                {
  
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" ");
Console.Write("ACTUALIZANDO PRODUCTO");
Console.ResetColor();

for (int ciclo = 0; ciclo < 3; ciclo++)
                    {
     for (int i = 0; i < 3; i++)
                        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write(".");
          Console.ResetColor();
          Thread.Sleep(400);
                }
          Thread.Sleep(400);
          Console.Write("\b\b\b   \b\b\b");
            }

          GuardarProducto(productos, rutaArchivo);

           Console.ForegroundColor = ConsoleColor.Green;
           Console.WriteLine(" ");
           Console.WriteLine("\nPRODUCTO ACTUALIZADO CORRECTAMENTE.");
           Console.ResetColor();
             }
              else
                {
                 Console.ForegroundColor = ConsoleColor.Yellow;
                 Console.WriteLine("\nACTUALIZACION CANCELADA.");
                 Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO SE ENCONTRO NINGUN PRODUCTO CON ESE ID.");
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("\nDESEA ACTUALIZAR OTRO PRODUCTO? (SI/NO): ");
                repetir = Console.ReadLine().Trim().ToLower();
                if (repetir == "si" || repetir == "no")
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEBE INGRESAR 'SI' O 'NO'.");
                Console.ResetColor();
            }

        } while (repetir == "si");
    }

    static void Main(string[] args)
    {

        Almacen almacen1 = new Almacen();

        almacen1.CargarProductos(almacen1.productos, almacen1.rutaArchivo);

        almacen1.Menu();

    }

}