/*
 * Created by SharpDevelop.
 * User: Rodrigo Martin
 * Date: 19/06/2017
 * Time: 04:22 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Integrador//continuar en lineas:  1271,  y modulos: venta pasajes, consultar terminal como partida y como arribo//
{
	class Program
	{
		public static void Main(string[] args)
		{
			string a;
			ArrayList ListaTerminales = new ArrayList();
			ArrayList ListaBuses = new ArrayList();
			ArrayList ListaChoferes = new ArrayList();
			ArrayList ListaRecorridos = new ArrayList();
			ArrayList ListaViajes = new ArrayList();
			ArrayList ListaUsuarios = new ArrayList();
			
			int nroBus = 0, cantLegajos = 0, CantidadUsuarios = 0, CantidadPasajes = 0;
			do {
				limpiarPantalla();//MAIN//
				Console.WriteLine("¿A que modulo desea ingresar? ");
				Console.WriteLine("");
				Console.WriteLine("1)Armado de recorridos ");
				Console.WriteLine("2)Gestion de choferes ");
				Console.WriteLine("3)Venta de pasajes " );
				Console.WriteLine("4)Estadisticas ");
				Console.WriteLine("5)Salir del sistema" ) ;
				
				a = Console.ReadLine();
				
				
				switch(a){
						
						
						
					case "1"://ARMADO DE RECORRIDOS//
						do {
							limpiarPantalla();
							
							Console.WriteLine("1)Alta de terminales");
							Console.WriteLine("2)Alta de Omnibus");
							Console.WriteLine("3)Alta de recorrido");
							Console.WriteLine("4)Volver");
							a = Console.ReadLine();
							switch (a){
									
								case "1"://ALTA DE TERMINALES//
									//hacer la exception//
										
									 
									limpiarPantalla();
									terminales t1;
									string v1, v2;
									Console.WriteLine("Ingrese el nombre de la terminal: ");
									v1 = Console.ReadLine();
									Console.WriteLine("Ingrese el nombre de la ciudad: ");
									v2 = Console.ReadLine();
									
									t1 = new terminales(v1,v2);
									ListaTerminales.Add(t1);
									Console.WriteLine("La terminal ha sido dada de alta");
									Console.Write("Presione una tecla para continuar " +
									              "                                            ");
									Console.Write(" " +
									              " ");
									Console.ReadKey(true);
									
									
									
									continue;
									
								case "2"://ALTA DE OMNIBUS//
									limpiarPantalla();
									int  capac;
									string marca, modelo, tipo;
									Console.WriteLine("Ingrese la marca");
									marca = Console.ReadLine();
									Console.WriteLine("Ingrese el modelo");
									modelo = Console.ReadLine();
									Console.WriteLine("Ingrese la capacidad");
									capac =Int32.Parse(Console.ReadLine());
									Console.WriteLine("Ingrese el tipo");
									tipo = Console.ReadLine();
									omnibus micro = new omnibus(marca, modelo, capac, tipo, nroBus);
									Console.WriteLine("El omnibus fue dado de alta correctamente. A la unidad se le asigno el numero " + nroBus);
									ListaBuses.Add(micro);
									nroBus++;
									Console.WriteLine("Presione una tecla para continuar");
									Console.ReadKey(true);
									continue;
									
									
								case "3"://ALTA DE RECORRIDO//
									limpiarPantalla();
									
									string b, i1;
									
									ArrayList  seleccion = new ArrayList();
									
									do{
										int i = 1;
										ArrayList provisorio = new ArrayList();
										
										limpiarPantalla();
										Console.WriteLine("Seleccione las terminales del recorrido, para finalizar presione 0");//muestra todas las ciudades disponibles//
										foreach (terminales t in ListaTerminales) {
											
											Console.WriteLine(i + ")" + t.getCiudad);
											i1=i.ToString();
											
											asignacion asignacion2 = new asignacion(i1,t.getCiudad);
											
											
											provisorio.Add(asignacion2);
											i++;
											
											
										}
										foreach (string q in seleccion) {
											
											Console.WriteLine(q);
										}
										b = Console.ReadLine();//variable con la seleccion de la ciudad deseada//
										
										foreach (asignacion p in provisorio) {//revisa la lista de las ciudades con la asignacion de los numeros. si la variable coincide con el numero de la ciudad//
											if ( b == p.getNumero.ToString()) {      //se agrega el nombre de la ciudad a la lista seleccion//
												seleccion.Add(p.getCiudad);
												
											}
											
										}
									
										
									}
									while (b!="0");
									if (seleccion.Count > 0) {
										recorrido recorridito = new recorrido(seleccion);
										
										
										ListaRecorridos.Add(recorridito);
										
										Console.WriteLine("El recorrido se ha dado de alta correctamente");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
									}
									else{
										Console.WriteLine("No se ha seleccionado ningun recorrido. Vuelva a intentarlo");
										Console.WriteLine("Presione una tecla para continuar");
									Console.ReadKey(true);
									}
									continue;
									
								case "4"://SALIR//
									continue;
									
									default :
										Console.WriteLine("Ha ingresado un valor incorrecto");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
									continue ;
									
									
									
									
							}
						}
						
						
						while (a!="4");
						continue;
						
					case "2"://GESTION DE CHOFERES//
						do {
							limpiarPantalla();
							Console.WriteLine("");
							Console.WriteLine("");
							Console.WriteLine("1)Alta de choferes");
							Console.WriteLine("2)Asignacion de recorrido");
							Console.WriteLine("3)Volver");
							a = Console.ReadLine();
							
							switch(a){
								case "1"://ALTA DE CHOFERES//
									bool listo = false;
									while(!listo){
										limpiarPantalla();
										
										string nom, ap;
										int dni, nroleg;
										Console.WriteLine("Ingrese el nombre");
										nom = Console.ReadLine();
										Console.WriteLine("Ingrese el apellido");
										ap = Console.ReadLine();
										Console.WriteLine("Ingrese el dni");
										dni = Int32.Parse(Console.ReadLine());
										bool existe = false;
										foreach (chofer c in ListaChoferes) {
											if (dni == c.getDni) {
												Console.WriteLine("Ya existe un chofer con ese dni en la empresa");
												Console.WriteLine("Presione una tecla para continuar");
												Console.ReadKey(true);
												existe = true;
												
											}
										}
										if(existe == false){
											nroleg = cantLegajos;
											chofer chofi = new chofer(nom, ap,dni, nroleg);
											ListaChoferes.Add(chofi);
											Console.WriteLine("El chofer fue dado de alta correctamente. Su numero de legajo es " + nroleg);
											cantLegajos++;
											listo = true;
											Console.WriteLine("Presione una tecla para continuar");
											Console.ReadKey(true);
										}
									}
									break;
									
								case "2"://ASIGNACION DE RECORRIDO//
									listo = false;
									while (!listo) {
									limpiarPantalla();
									int u=1, w, y, z;
									string j;
									Console.WriteLine("Seleccione el chofer");
									foreach (chofer c in ListaChoferes) {
										Console.WriteLine(u +") " + c.getNombre + " " + c.getApellido + " <" + c.getNumeroLegajo +">");
										u++;
										
									}
									u=1;
									j = Console.ReadLine();
									w = Int32.Parse(j);
									chofer choferViaje = new chofer();
									
									
									choferViaje = (chofer)ListaChoferes[w-1];
									
									
									
									Console.WriteLine("Seleccione el omnibus");
									foreach (omnibus o in ListaBuses) {
										Console.WriteLine(u + ") " + o.getUnidad + " <" + o.getMarca + "-" + o.getModelo + "-" + o.getTipo + "-" + o.getCapacidad + ">");
										u++;
									}
									u=1;
									j=Console.ReadLine();
									y=Int32.Parse(j);
									omnibus busViaje = new omnibus();
									busViaje = (omnibus) ListaBuses[y-1];
									
									
									
									Console.WriteLine("Seleccione el recorrido");
									string recorridoImprimir = "";
									foreach (recorrido r in ListaRecorridos) {
										for (int s = 1; s <= r.getRecorridito.Count; s++) {
											
											recorridoImprimir = recorridoImprimir + " - " +  r.getRecorridito[s-1];
										
										
										}
										Console.WriteLine(u + ") " + ((string) recorridoImprimir));
										recorridoImprimir = "";
										u++;
									}
									u=1;
									j = Console.ReadLine();
									z = Int32.Parse(j);
									recorrido recorridoViaje = new recorrido();
									recorridoViaje = (recorrido) ListaRecorridos[z-1];
									
										
									
										
									Console.WriteLine("Seleccione el dia donde hacer el recorrido");
									diasSemana dias = new diasSemana();
									string u1;
									ArrayList provisorio1 = new ArrayList();
									ArrayList diasviaje = new ArrayList(){"Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"};
									foreach (string q in diasviaje) {
										Console.WriteLine(u + ") " + q);
										u1 = u.ToString();
										asignacion asignacion3 = new asignacion(u1, q);
										provisorio1.Add(asignacion3);
										u++;
									}
									u = 1;
									j = Console.ReadLine();
									
									foreach (asignacion asig in provisorio1) {
										if (j == asig.getNumero) {
											dias.setDiaSeleccion = asig.getCiudad;//asig.getCiudad retorna el dia de la semana, ya que en este caso utilice la clase asignacion para asignar numeros a los dias de la semana//
										}
									}
									bool existe = false;
									if (dias.getDiaSeleccion == "Lunes" && choferViaje.getViajeLunes == true) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
										
									}
									if (dias.getDiaSeleccion == "Martes" && choferViaje.getViajeMartes == true) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Miercoles" && choferViaje.getViajeMiercoles == true) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Jueves" && choferViaje.getViajeJueves == true) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Viernes" && choferViaje.getViajeViernes == true) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Sabado" && choferViaje.getViajeSabado == true) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Domingo" && choferViaje.getViajeDomingo == true ) {
										Console.WriteLine("El chofer ya hace un viaje ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Lunes" && busViaje.getViajeLunes == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Martes" && busViaje.getViajeMartes == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Miercoles" && busViaje.getViajeMiercoles == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Jueves" && busViaje.getViajeJueves == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Viernes" && busViaje.getViajeViernes == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Sabado" && busViaje.getViajeSabado == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (dias.getDiaSeleccion == "Domingo" && busViaje.getViajeDomingo == true) {
										Console.WriteLine("El omnibus ya esta reservado ese dia");
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										existe = true;
									}
									if (existe == false){
										
										viaje nuevoViaje = new viaje(choferViaje,busViaje,recorridoViaje,dias.getDiaSeleccion);
										((recorrido)nuevoViaje.getRecorrido).setHabilitado = true;
										ListaViajes.Add(nuevoViaje);
										((chofer) ListaChoferes[w-1]).asignarDias(dias.getDiaSeleccion);
										((omnibus) ListaBuses[y-1]).asignarDias(dias.getDiaSeleccion);
										((recorrido) ListaRecorridos[z-1]).setHabilitado = true;
										
										
										Console.WriteLine("La asignacion del recorrido fue dada de alta correctamente");
										
										Console.WriteLine("Presione una tecla para continuar");
										Console.ReadKey(true);
										listo = true;
									}
									
									
									}
									continue;
									
							}
							
							
							
							
							
							continue;
						}
						
				
				
				while(a !="3");
				continue;
				
			case "3"://VENTA DE PASAJES//
				do{
				limpiarPantalla();
				Console.WriteLine(" ");
				Console.WriteLine(" ");
				Console.WriteLine("1) Alta de usuario ");
				Console.WriteLine("2) Compra de pasajes ");
				Console.WriteLine("3) Volver ");
				a = Console.ReadLine();
				switch (a) {
					case "1" ://ALTA DE USUARIOS//
						bool existe = false;
						bool listo = false;
						while(!listo){
						limpiarPantalla();
						string nombre, apellido, fechanacimiento;
						int dni, numerousuario;
						Console.WriteLine("Ingrese el nombre");
						nombre = Console.ReadLine();
						Console.WriteLine("Ingrese el Apellido");
						apellido = Console.ReadLine();
						Console.WriteLine("Ingrese el Dni");
						dni = Int32.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese la fecha de nacimiento");
						fechanacimiento = Console.ReadLine();
						foreach (usuario u in ListaUsuarios) {
							if (dni == u.getDni) {
								Console.WriteLine("Ya existe un usuario con ese dni en la empresa");
								Console.WriteLine("Presione una tecla para continuar");
								Console.ReadKey(true);
								existe = true ;
								break;
							}
							else{
								existe = false;
							}
							
						}
						if (existe == false){
						numerousuario = CantidadUsuarios;
						usuario usua = new usuario(nombre, apellido, dni, fechanacimiento, numerousuario);
						ListaUsuarios.Add(usua);
						Console.WriteLine("El usuario fue dado de alta correctamente con el numero de usuario " + numerousuario);
						CantidadUsuarios++;
						listo = true;
						Console.WriteLine("Presione una tecla para continuar");
						Console.ReadKey(true);
											}
						
						}
						
						continue;//continue alta de usuarios//
						
					case "2"://compra pasajes//
						listo = false;
						int numusuario = 0, dni1 = 0;
						while (!listo){
						limpiarPantalla();
						
						bool existe1 = false;
						Console.WriteLine("Ingrese el numero de usuario");
						numusuario = Int32.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese el DNI del usuario");
						dni1 = Int32.Parse(Console.ReadLine());
						
						foreach (usuario u in ListaUsuarios) {
							
						
							if (dni1 == u.getDni && ListaUsuarios.Count > 0 && numusuario == u.getNumeroUsuario) {
								listo = true;
								existe1 = true;
							}
							
							
							
						}
						if (!existe1) {
							Console.WriteLine("El usuario solicitado no existe dentro del sistema");
								listo = false;
								Console.WriteLine("Presione una tecla para continuar");
								Console.ReadKey(true);
								
						}
						
						}
						ArrayList provisorio = new ArrayList();
						ArrayList seleccion = new ArrayList();
						ArrayList viajeItinerario = new ArrayList();
						string v1, v2, i1;
						int i = 1;
						listo = false;
						while (!listo){
							while (!listo) {
								
							
						seleccion = new ArrayList();//no resetea la variable seleccion//
						limpiarPantalla();
						Console.WriteLine("Seleccione la Terminal de partida");
						foreach (terminales t in ListaTerminales) {//imprime todas las terminales y les asigna un valor numerico en string//
							
							Console.WriteLine(i + ")" + t.getCiudad);
							i1=i.ToString();
							
							asignacion asignacion2 = new asignacion(i1,t.getCiudad);
							
							
							provisorio.Add(asignacion2);
							i++;
							
							
						}
						v1 = Console.ReadLine();
						foreach (asignacion p in provisorio) {//revisa la lista de las ciudades con la asignacion de los numeros. si la variable coincide con el numero de la ciudad//
							if ( v1 == p.getNumero.ToString()) {      //se agrega el nombre de la ciudad a la lista seleccion//
								seleccion.Add(p.getCiudad);
								
							}
						}
						i=1;
						Console.WriteLine("Seleccione la Terminal de arribo");
						foreach (terminales t in ListaTerminales) {
							
							Console.WriteLine(i + ")" + t.getCiudad);
							i1=i.ToString();
							
							asignacion asignacion2 = new asignacion(i1,t.getCiudad);
							
							
							provisorio.Add(asignacion2);
							i++;
							
							
						}
						v2 = Console.ReadLine();
						foreach (asignacion p in provisorio) {//revisa la lista de las ciudades con la asignacion de los numeros. si la variable coincide con el numero de la ciudad//
							if ( v2 == p.getNumero.ToString()) {      //se agrega el nombre de la ciudad a la lista seleccion//
								seleccion.Add(p.getCiudad);
								
							}
						}
						if (seleccion[0] == seleccion[1]) {
							Console.WriteLine("Las terminales de partida y arribo son las mismas");
							listo = false;
							i=1;
							seleccion = new ArrayList();//no resetea la variable seleccion//
							Console.WriteLine("Presione una tecla para continuar");
							Console.ReadKey(true);
							
						}
						else{
							listo = true;
						}
							}
						
						
						i = 1;
						bool partida = false;
						bool arribo = false;
						string partida1, arribo1;
						
						partida1 = seleccion[0].ToString();
						arribo1 = seleccion[1].ToString();
						foreach (viaje v in ListaViajes) {
								foreach (string ar in v.getRecorrido.getRecorridito) {
									
									
										
									
										if (partida1 == ar) {
											partida = true;
										}
										if ( partida == true && arribo1 == ar) {
											arribo = true;
										}
										
									
									
									
								}
							if (partida && arribo) {
								
								
								viajeItinerario.Add(v);
								
								
							}
							
															
						}
						if (viajeItinerario.Count > 0) {
							listo = true;
						}
						else{
							Console.WriteLine("No existe ningun recorrido con las terminales de partida y arribo seleccionadas");//despues de este error, no puedo reiniciar la variable seleccion y me dice que las terminales de partida y arribo son siempre iguales//
							Console.WriteLine("Presione una tecla para continuar");
							Console.ReadKey(true);
							seleccion = new ArrayList();//no resetea la variable seleccion//
							listo = false;
							}
						}
						i = 0;
						string partida2, arribo2;
						partida2 = seleccion[0].ToString();
						arribo2 = seleccion[1].ToString();
						int k = 1, j;
						string h = k.ToString();
						limpiarPantalla();
						Console.WriteLine("Seleccione el itinerario");
						foreach (viaje v in viajeItinerario) {
							j = v.getRecorrido.getRecorridito.Count;
							for (int l = j; l > 0; l--) {
								if (v.getRecorrido.getRecorridito[l-1].ToString() == arribo2) {
									for (int m = 0; m < j; m++) {
										if (v.getRecorrido.getRecorridito[m].ToString() == partida2) {
											
										
										
																
							Console.WriteLine(h + ") Saliendo de " + v.getRecorrido.getRecorridito[0] + " y llegando a " + v.getRecorrido.getRecorridito[j-1] + "<" + ((int)j-2) + " paradas intermedias, " + v.getDiaSemana + ", " + v.getColectivo.getTipo + ">") ;
							k++;
							h = k.ToString();
										}
									}
								}
							}
						}
						v1 = Console.ReadLine();
						j = Int32.Parse(v1);
						Console.WriteLine("¿Cuantos pasajes desea?");
						v2 = Console.ReadLine();
						k = Int32.Parse(v2);
						foreach (usuario u in ListaUsuarios) {
							if (dni1 == u.getDni && numusuario == u.getNumeroUsuario) {
								u.setPasajesComprados = u.getPasajesComprados + k;
							}
						}
						foreach (terminales t in ListaTerminales) {
							if (seleccion[0].ToString() == t.getCiudad) {
								t.setPasajePartida = t.getPasajePartida + k;
							}
							if (seleccion[1].ToString() == t.getCiudad) {
								t.setPasajeArribo = t.getPasajeArribo + k;
							}
						
						}
						CantidadPasajes = CantidadPasajes + k;
						Console.WriteLine("La venta se ha realizado con exito");
						Console.WriteLine("Presione una tecla para continuar");
						Console.ReadKey(true);
						continue;//continue compra pasajes//
				}
				}
				while(a != "3");
				
				continue;//continue venta pasajes//
				
				
			case "4"://estadisticas//
				do{
				limpiarPantalla();
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("1)Consultar total de pasajes vendidos");
				Console.WriteLine("2)Consultar usuarios");
				Console.WriteLine("3)Consultar terminal como partida " );
				Console.WriteLine("4)Consultar terminal como arribo");
				Console.WriteLine("5)Volver" ) ;
				
				a = Console.ReadLine();
				switch (a) {
					case "1":
						limpiarPantalla();
						Console.WriteLine("En total se han vendido " + CantidadPasajes + " pasajes");
						Console.WriteLine("Presione una tecla para continuar");
						Console.ReadKey(true);
						break;
					case "2":
						int f, pasajes;
						string nom, ap;
						ArrayList ListaUsuariosOrdenada = ordenarUsuarios(ListaUsuarios);
						f = 1;
						foreach (usuario u in ListaUsuariosOrdenada) {
							nom = u.getNombre;
							ap = u.getApellido;
							pasajes = u.getPasajesComprados;
							Console.WriteLine(f + ") " + nom + " " + ap + " " + "<" + pasajes + ">");
							f++;
						}
						Console.WriteLine("Presione una tecla para continuar");
						Console.ReadKey(true);
						break;
						
					case "3":
						
					default:
						Console.WriteLine("Ha ingresado un valor incorrecto");
						Console.WriteLine("Presione una tecla para continuar");
						Console.ReadKey(true);
						
						break;
				}	
				}
				while(a!="5");
				a = "0";
					
				
				
				
				continue;//continue estadisticas//
			}
			
			
			
		
			}
		while (a!= "5");
		
		// TODO: Implement Functionality Here
		
		Console.Write("Presione una tecla para finalizar . . . ");
		Console.ReadKey(true);
		}
	
	private static void limpiarPantalla()
	{
		Console.Clear();
		Console.WriteLine("********************************************************************************" +
		                  "*****                             Micritos                                 *****" +
		                  "********************************************************************************");
	}
	class omnibus
	{
		private string Marca;
		private string Modelo;
		private int Capacidad;
		private string Tipo;
		private int Unidad;
		private bool viajeLunes = false;
		private bool viajeMartes = false;
		private bool viajeMiercoles = false;
		private bool viajeJueves = false;
		private bool viajeViernes = false;
		private bool viajeSabado = false;
		private bool viajeDomingo = false;
		
		
		public string getMarca
		{
			get
			{
				return Marca;
			}
		}
		public string getModelo
		{
			get
			{
				return Modelo;
			}
		}
		public int getCapacidad
		{
			get
			{
				return Capacidad;
			}
		}
		public string getTipo
		{
			get
			{
				return Tipo;
			}
		}
		public int getUnidad
		{
			get
			{
				return Unidad;
			}
		}
		public bool getViajeLunes{
			get{
				return viajeLunes;
			}
		}
		public bool setViajeLunes{
			set{
				viajeLunes = value;
			}
		}
		public bool getViajeMartes{
			get{
				return viajeMartes;
			}
		}
		public bool getViajeMiercoles{
			get{
				return viajeMiercoles;
			}
		}
		public bool getViajeJueves{
			get{
				return viajeJueves;
			}
		}
		public bool getViajeViernes{
			get{
				return viajeViernes;
			}
		}
		public bool getViajeSabado{
			get{
				return viajeSabado;
			}
		}
		public bool getViajeDomingo{
			get{
				return viajeDomingo;
			}
		}
		public bool setViajeMartes{
			set{
				viajeMartes = value;
			}
		}
		public bool setViajeMiercoles{
			set{
				viajeMiercoles = value;
			}
		}
		public bool setViajeJueves{
			set{
				viajeJueves = value;
			}
		}
		public bool setViajeViernes{
			set{
				viajeViernes = value;
			}
		}
		public bool setViajeSabado{
			set{
				viajeSabado = value;
			}
		}
		public bool setViajeDomingo{
			set{
				viajeDomingo = value;
			}
		}
		
		public omnibus (string marca, string modelo, int capacidad, string tipo, int unidad){
			this.Marca = marca;
			this.Modelo = modelo;
			this.Capacidad = capacidad;
			this.Tipo = tipo;
			this.Unidad = unidad;
		}
		
		public omnibus (){
		}
		public void asignarDias(string variable){
		    
			if (variable == "Lunes") {
				this.setViajeLunes = true;
			}
			if (variable == "Martes") {
				this.setViajeMartes = true;
			}
			if (variable == "Miercoles") {
				this.setViajeMiercoles = true;
			}
			if (variable == "Jueves") {
				this.setViajeJueves = true;
			}
			if (variable == "Viernes") {
				this.setViajeViernes = true;
			}
			if (variable == "Sabado") {
				this.setViajeSabado = true;
			}
			if (variable == "Domingo") {
				this.setViajeDomingo = true;
			}	
		                                        }
		}	
	class chofer
	{
		private string Nombre;
		private string Apellido;
		private int Dni;
		private int NumeroLegajo;
		private bool viajeLunes = false;
		private bool viajeMartes = false;
		private bool viajeMiercoles = false;
		private bool viajeJueves = false;
		private bool viajeViernes = false;
		private bool viajeSabado = false;
		private bool viajeDomingo = false;
		
		
		public string getNombre
		{
			
			get
			{
				return Nombre;
			}
			
		}
		public string getApellido
		{
			get
			{
				return Apellido;
			}
		}
		public int getDni
		{
			get
			{
				return Dni;
			}
		}
		public int getNumeroLegajo
		{
			get
			{
				return NumeroLegajo;
			}
		}
		
		public bool getViajeLunes{
			get{
				return viajeLunes;
			}
		}
		public bool getViajeMartes{
			get{
				return viajeMartes;
			}
		}
		public bool getViajeMiercoles{
			get{
				return viajeMiercoles;
			}
		}
		public bool getViajeJueves{
			get{
				return viajeJueves;
			}
		}
		public bool getViajeViernes{
			get{
				return viajeViernes;
			}
		}
		public bool getViajeSabado{
			get{
				return viajeSabado;
			}
		}
		public bool getViajeDomingo{
			get{
				return viajeDomingo;
			}
		}
		public bool setViajeLunes{
			set{
				viajeLunes = value;
			}
		}
		public bool setViajeMartes{
			set{
				viajeMartes = value;
			}
		}
		public bool setViajeMiercoles{
			set{
				viajeMiercoles = value;
			}
		}
		public bool setViajeJueves {
			set{
				viajeJueves = value;
			}
		}
		public bool setViajeViernes{
			set{
				viajeViernes = value;
			}
		}
		public bool setViajeSabado{
			set{
				viajeSabado = value;
			}
		}
		public bool setViajeDomingo{
			set{
				viajeDomingo = value;
			}
		}
		
		
		public chofer (string nombre, string apellido, int dni, int numeroLegajo){
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Dni = dni;
			this.NumeroLegajo = numeroLegajo;
			
		}
		public chofer (string nombre, string apellido, string dni, string numeroLegajo){
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Dni = Int32.Parse(dni);
			this.NumeroLegajo = Int32.Parse(numeroLegajo);
			
		}
		
		public chofer() {
			
		}
		public void asignarDias(string variable){
			if (variable == "Lunes") {
				this.setViajeLunes = true;
			}
			if (variable == "Martes") {
				this.setViajeMartes = true;
			}
			if (variable == "Miercoles") {
				this.setViajeMiercoles = true;
			}
			if (variable == "Jueves") {
				this.setViajeJueves = true;
			}
			if (variable == "Viernes") {
				this.setViajeViernes = true;
			}
			if (variable == "Sabado") {
				this.setViajeSabado = true;
			}
			if (variable == "Domingo") {
				this.setViajeDomingo = true;
			}
		}
		
	}
	class usuario
	{
		private string Nombre;
		private string Apellido;
		private int Dni;
		private string FechaNacimiento;
		private int NumeroUsuario;
		private int PasajesComprados;
		
		public string getNombre
		{
			get
			{
				return Nombre;
			}
		}
		public string getApellido
		{
			get
			{
				return Apellido;
			}
		}
		public int getDni
		{
			get
			{
				return Dni;
			}
		}
		public string getFechaNacimiento
		{
			get
			{
				return FechaNacimiento;
			}
		}
		public int getNumeroUsuario
		{
			get
			{
				return NumeroUsuario;
			}
		}
		public int getPasajesComprados{
			get{
				return PasajesComprados;
			}
		}
		public int setPasajesComprados{
			set{
				PasajesComprados = value;
			}
		}
		
		
		public usuario (string nombre, string apellido, int dni, string fechaNacimiento, int numerousuario){
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Dni = dni;
			this.FechaNacimiento = fechaNacimiento;
			this.NumeroUsuario = numerousuario;
		}
	}
	class terminales
	{
		
		private string Nombre;
		private string Ciudad;
		private int pasajePartida;
		private int pasajeArribo;
		
		public string getNombre
		{
			get
			{
				return Nombre;
			}
		}
		public string getCiudad
		{
			get
			{
				return Ciudad;
			}
		}
		public int getPasajePartida{
			get{
				return pasajePartida;
			}
		}
		public int setPasajePartida{
			set{
				pasajePartida = pasajePartida + value;
			}
		}
		public int getPasajeArribo{
			get{
				return pasajeArribo;
			}
		}
		public int setPasajeArribo{
			set{
				pasajeArribo = pasajeArribo + value;
			}
		}
		
		public terminales (string nombre, string ciudad){
			this.Nombre = nombre;
			this.Ciudad = ciudad;
		}
		
		
		
	}
	class asignacion
	{
		private string Numero;
		private string Ciudad;
		
		public string getNumero {
			get{
				return Numero;
			}
		}
		public string getCiudad{
			get{
				return Ciudad;
			}
		}
		public string setNumero {
			set{
				Numero = value;
			}
		}
		public string setCiudad{
			set {
				Ciudad = value;
			}
		}
		
		public asignacion (string numero, string ciudad){
			this.Numero = numero;
			this.Ciudad = ciudad;
		}
	}
	class viaje{
		private chofer Chofercito;
		private omnibus Colectivo;
		private recorrido Recorrido;
		private string diaSemana;
		private bool viajeItinerario = false;
		
		public chofer getChofercito{
			get{
				return Chofercito;
			}
		}
		public omnibus getColectivo{
			get{
				return Colectivo;
			}
		}
		public recorrido getRecorrido{
			get{
				return Recorrido;
			}
		}
		public string getDiaSemana{
			get{
				return diaSemana;
			}
		}
		
		public chofer setChofercito{
			set{
				Chofercito = value;
			}
		}
		public omnibus setColectivo{
			set{
				Colectivo = value;
			}
		}
		public recorrido setRecorrido{
			set{
				Recorrido = value;
			}
		}
		public string setDiaSemana{
			set{
				diaSemana = value;
			}
		}
		public bool getviajeItinerario{
			get{
				return viajeItinerario;
			}
		}
		public bool setviajeItinerario{
			set{
				viajeItinerario = value;
			}
		}
		public viaje (chofer chofercito, omnibus colectivo, recorrido rEcorrido, string diasemana){
			this.Chofercito = chofercito;
			this.Colectivo = colectivo;
			this.Recorrido = rEcorrido;
			this.diaSemana = diasemana;
		}
		
	}
	class recorrido
	{
		private ArrayList recorridito;
		private bool habilitado = false;
		
		public void imprimirRecorrido()
		{
			Console.WriteLine(recorridito);
		}
		public ArrayList getRecorridito{
			get{
				return recorridito;
			}
		}
		
		public ArrayList setRecorrido{
			set {
				recorridito = value;
			}
		}
		public bool getHabilitado{
			get{
				return habilitado;
			}
		}
		public bool setHabilitado{
			set{
				habilitado = value;
			}
		}
		
		public recorrido (ArrayList Recorridito)
		{
			this.recorridito = Recorridito;
		}
		public recorrido (){
			
		}
	}
	class diasSemana
	{
		private string diaSeleccion ;
		
		public string getDiaSeleccion{
			get{
				return diaSeleccion;
			}
		}
		public string setDiaSeleccion{
			set{
				diaSeleccion = value ;
			}
		}
		
	}
	
	
	private static ArrayList ordenarUsuarios(ArrayList datos){
			int n = datos.Count;
			ArrayList [] datos2 = new ArrayList[n];
			for(int i=0; i<n; i++){
			int j = i;
			while((j>0) && ((usuario)datos[i]).getPasajesComprados<((usuario)datos2[j-1]).getPasajesComprados){
				datos2[j] = datos2[j-1];
				j--;
			}
			datos2[j].Add(datos[i]);//el indice esta fuera de rango, debe ser un valor no negativo e inferior al tamaño de la coleccion//
			}
			return datos2;
}

	
	}
	
}

	