using static System.Console;

int cantidad = 0;
Contacto[] contactos = new Contacto[cantidad];

bool funcionando;
int opcion = 0;
do
{
    funcionando = true;
    var vec_menu = new string[] { "Ver Contactos", "Agregar Contacto", "Buscar Contacto", "Salir" };
    var vec_volver = new string[] { "Volver", "Cerrar Programa" };
    var vec_menu1 = new string[] { "Agregar otro Contacto", "Volver" };
    var vec_menu2 = new string[] { "Volver", "Buscar otro Contacto" };
    var vec_volver2 = new string[] { "Volver", "Buscar otro Contacto" };
    var vec_volver3 = new string[] { "Volver", "Ver Detalles", "Eliminar" };
    var vec_volver4 = new string[] { "Volver", "Eliminar" };
    var vec_volver5 = new string[] { "Volver", "Siguiente" };
    Clear();
    WriteLine("\nMENÚ:\n\nSeleccione una opción:");
    opcion = SeleccionMenu(vec_menu, 4);
    WriteLine();
    if (opcion == 1)
    {
        Clear();
        opcion = 0;
        OrdenarContactos(contactos, cantidad);
        VerContactos(contactos, cantidad);
        bool correcto;
        do
        {
            correcto = true;
            opcion = SeleccionMenu(vec_volver, 2);
            if (opcion == 1)
            {
                funcionando = false;
            }
            else if (opcion == 2)
            {
                funcionando = true;
            }
            else
            {
                Error();
                correcto = false;
            }
        } while (!correcto);
    }
    else if (opcion == 2)
    {
        Clear();
        opcion = 0;
        bool correcto;
        do
        {
            //Array.Resize(ref contactos, contactos.Length + 1);
            AgregarEspacioVec(ref contactos, cantidad);
            IngresarContactos(contactos, ref cantidad);
            correcto = true;
            bool repetir;
            do
            {
                repetir = true;
                opcion = SeleccionMenu(vec_menu1, 2);
                if (opcion == 1)
                {
                    Clear();
                    correcto = false;
                }
                else if (opcion == 2)
                {
                    funcionando = false;
                }
                else if (opcion == 3)
                {
                    funcionando = true;
                }
                else
                {
                    Error();
                    repetir = false;
                }
            } while (!repetir);
        } while (!correcto);
    }
    else if (opcion == 3)
    {
        bool activado;
        opcion = 0;
        do
        {
            Clear();
            activado = true;
            WriteLine("\nBUSCADOR:\n");
            WriteLine("Ingrese el email de la persona que desea buscar.\n\n");
            Write("Email: ");
            string email = ReadLine();
            BuscarContactos(contactos, cantidad, email);
            if (BuscarContactos(contactos, cantidad, email) <= -1)
            {
                bool repetir;
                do
                {
                    Clear();
                    repetir = true;
                    WriteLine("\nLa persona que se busca no existe o no se encuentra registrada.\n\n");
                    Thread.Sleep(750);
                    opcion = SeleccionMenu(vec_menu2, 2);
                    if (opcion == 1)
                    {
                        funcionando = false;
                    }
                    else if (opcion == 2)
                    {
                        activado = false;
                    }
                    else
                    {
                        Error();
                        repetir = false;
                    }
                } while (!repetir);
            }
            else
            {
                bool repetir_menu_cont;
                do
                {
                    Clear();
                    repetir_menu_cont = true;
                    int posicion = BuscarContactos(contactos, cantidad, email);
                    WriteLine("\n¡La persona que esta buscando se ha encontrado con éxito!\n");
                    WriteLine($"La persona se encuentra en la posición {posicion} del registro.\n");
                    opcion = SeleccionMenu(vec_volver3, 3);
                    if (opcion == 1)
                    {
                        funcionando = false;
                    }
                    else if (opcion == 2)
                    {
                        bool repetir;
                        do
                        {
                            Clear();
                            repetir = true;
                            opcion = 0;
                            WriteLine("\nDETALLES DEL CONTACTO:\n");
                            WriteLine("-------------------------");
                            WriteLine($"Apellido: {contactos[posicion].apellido}");
                            WriteLine($"Nombre: {contactos[posicion].nombre}");
                            WriteLine($"Email: {contactos[posicion].email}");
                            WriteLine("-------------------------");
                            opcion = SeleccionMenu(vec_volver4, 2);
                            if (opcion == 1)
                            {
                                funcionando = false;
                            }
                            else if (opcion == 2)
                            {
                                EliminarContacto(contactos, ref cantidad, posicion);
                                AnimacionEliminacion();
                                funcionando = false;
                            }
                            else
                            {
                                Error();
                                repetir = false;
                            }
                        } while (!repetir);
                    }
                    else if (opcion == 3)
                    {
                        EliminarContacto(contactos, ref cantidad, posicion);
                        AnimacionEliminacion();
                        funcionando = false;
                    }
                    else
                    {
                        Error();
                        repetir_menu_cont = false;
                    }
                } while (!repetir_menu_cont);
            }
        } while (!activado);
    }
    else if (opcion == 4)
    {
        AnimacionCierre();
        funcionando = true;
    }
    else
    {
        Error();
        funcionando = false;
    }
} while (!funcionando);

//########################################################## MAIN ################################################
//########################################################## MAIN ################################################
//########################################################## MAIN ################################################

static int SeleccionMenu(string[] vec_menu, int cantidad)
{
    WriteLine();
    for (int i = 0; i < cantidad; i++)
        WriteLine($"\t{i + 1}) {vec_menu[i]}\n");
    Write("Ingrese su opción: ");
    var opcion = int.Parse(ReadLine());
    return opcion;
}
static void AnimacionEliminacion()
{
    Thread.Sleep(500);
    Write("\nEliminando contacto");
    for (int i = 0; i <= 5; i++)
    {
        Thread.Sleep(250);
        Write(".");
    }
    WriteLine("\n\n¡Su contacto se ha eliminado con éxito!.");
    Thread.Sleep(1250);
}
static void AnimacionCierre()
{
    Thread.Sleep(500);
    Write("\nCerrando aplicación");
    for (int i = 0; i <= 5; i++)
    {
        Thread.Sleep(250);
        Write(".");
    }
    WriteLine("\n\nLa aplicación se ha cerrado con éxito.");
    Thread.Sleep(1250);
}
static void Error()
{
    Clear();
    WriteLine("\n¡Error!");
    WriteLine("La opción ingresada no es correcta.\n");
    WriteLine("Vuelva a ingresar la opción.");
    Thread.Sleep(2000);
}
static void OrdenarContactos(Contacto[] contactos, int cantidad)
{
    bool ordenado;
    int pasada = 0;
    do
    {
        ordenado = true;
        pasada = pasada + 1;
        for (int i = 0; i <= cantidad - pasada - 1; i++)
        {
            if (String.Compare(contactos[i].apellido, contactos[i + 1].apellido) == 1)
            {
                ordenado = false;
                Contacto[] aux_vec = new Contacto[1];
                aux_vec[0] = contactos[i];
                contactos[i] = contactos[i + 1];
                contactos[i + 1] = aux_vec[0];
            }
            else if (String.Compare(contactos[i].apellido, contactos[i + 1].apellido) == 0)
            {
                ordenado = false;
                Contacto[] aux_vec = new Contacto[1];
                aux_vec[0] = contactos[i];
                contactos[i] = contactos[i + 1];
                contactos[i + 1] = aux_vec[0];
            }
        }
    } while (!ordenado);
}
static int BuscarContactos(Contacto[] contactos, int cantidad, string email)
{
    cantidad = contactos.Length;
    for (int i = 0; i < cantidad; i++)
    {
        if (email == contactos[i].email)
        {
            return i;
        }
    }
    WriteLine("La persona que se busca no se encuentra registrada.");
    return -1;
}
static void EliminarContacto(Contacto[] contactos, ref int cantidad, int posicion)
{
    for (int i = posicion; i < cantidad - 1; i++)
        contactos[i] = contactos[i + 1];
    cantidad = cantidad - 1;
}
//###################################### No Funciona ########################################################
//###################################### No Funciona ########################################################
/*static void EliminarContactoDos(ref Contacto[] contactos, ref int cantidad, int posicion)
{
    for (int i = posicion; i < cantidad - 1; i++)
        contactos[i] = contactos[i + 1];
    cantidad--;
    Contacto[] aux_vec = new Contacto[cantidad];
    for (int i = 0; i < cantidad; i++)
        aux_vec[i] = contactos[i];
    contactos = new Contacto[cantidad];
    for(int i = 0; i < cantidad; i++)
        contactos[i] = aux_vec[i];
}*/
//###################################### No Funciona ########################################################
//###################################### No Funciona ########################################################
static void AgregarEspacioVec(ref Contacto[] contactos, int cantidad)
{
    Contacto[] aux_vec = new Contacto[cantidad];
    for (int i = 0; i < cantidad; i++)
        aux_vec[i] = contactos[i];
    contactos = new Contacto[cantidad + 1];
    for (int i = 0; i < cantidad; i++)
        contactos[i] = aux_vec[i];
}
static void VerContactos(Contacto[] contactos, int cantidad)
//if (cantidad <= 10)
{
    Clear();
    WriteLine("\nLista de Contactos:\n");
    WriteLine("-------------------------");
    for (int i = 0; i < cantidad; i++)
    {
        WriteLine($"Apellido: {contactos[i].apellido}");
        WriteLine($"Nombre: {contactos[i].nombre}");
        WriteLine($"Email: {contactos[i].email}");
        WriteLine("-------------------------");
    }
}
/*else
{
    int residuo = cantidad % 10;
    int vueltas = 0;
    if (residuo == 0)
    {
        vueltas = cantidad / 10;
    }
    else
    {
        vueltas = (cantidad / 10) + 1;
    }
    bool repetir;
    bool repetir2;
    int opcion = 0;
    int inicio = 0;
    int final = 0;
    do
    {
        repetir = true;
        for (int i = 0; i < vueltas; i++)
        {
            do
            {
                repetir2 = true;
                final = final + 10;
                inicio = final - 10;
                Pantallas(contactos, inicio, final);
                Write("Opcion: ");
                opcion = int.Parse(ReadLine());
                if (opcion == 1)
                {
                    i = i - 1;
                }
            } while (!repetir2);
        }
    } while (!repetir);
}
}*/
static void Pantallas(Contacto[] contactos, int inicio, int final)
{
    for (int i = inicio; i < final; i++)
    {
        WriteLine($"{i}");
    }
}
static void IngresarContactos(Contacto[] contactos, ref int cantidad)
{
    Contacto cont;
    WriteLine("\nIngrese los datos del contacto:\n");
    Write("Apellido: ");
    cont.apellido = ReadLine();
    Write("Nombre: ");
    cont.nombre = ReadLine();
    Write("Email: ");
    cont.email = ReadLine();
    contactos[cantidad++] = cont;
    WriteLine("\nEl contacto se ha ingresado con éxito!");
}
struct Contacto
{
    public string apellido, nombre, email;
}