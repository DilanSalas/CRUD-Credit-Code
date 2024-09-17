using CreditFullSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CreditFullSA.Controllers
{
    public class CreditoController : Controller
    { 
        private readonly DbContextCreditos _context;
        
        public CreditoController(DbContextCreditos context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _context.Creditos.Where(c => c.estado == 'T').ToListAsync();
            return View(listado);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind] Credito credito)
        {
            if (credito == null) 
            {
                return View(null);
            }
            
            switch (credito.plazo)
            {
                case "6 meses":
                    credito.montoInteres = credito.montoSolicitar * 0.388m;
                    break;
                case "12 meses":
                    credito.montoInteres = credito.montoSolicitar * 0.2178m;
                    break;
                case "18 meses":
                    credito.montoInteres = credito.montoSolicitar * 0.1973m;
                    break;
                case "24 meses":
                    credito.montoInteres = credito.montoSolicitar * 0.1755m;
                    break;
                default:
                    break;
            }

            credito.numeroSolicitud = 0;
            credito.estado = 'T';

            _context.Creditos.Add(credito);
            await _context.SaveChangesAsync();

            string html = "Bienvenidos a CreditFullSA web CR gracias por formar parte " +
                    "de nuestra plataforma.<br>A continuación detallamos los datos de su credito solicitado " +
                    "en nuestra plataforma web:";
            html += "<br><b>Email: </b> " + credito.email;
            html += "<br><b>Nombre completo:</b> " + credito.cedula;
            html += "<br><b>Nombre completo:</b> " + credito.nombreCompleto;
            html += "<br><b>Su linea de credito es: </b>" + credito.lineaCredito;
            html += "<br><b>El monto a solicitar es: </b>" + credito.montoSolicitar;
            html += "<br><b>El monto de intereses según el plazo: </b>" + credito.montoInteres;
            html += "<br><b>El plazo de pago: </b>" + credito.plazo;
            html += "<br><b>Fecha de la solicitud: </b>" + credito.fecha;
            html += "<br><b>Su número de solicitud: </b>" + credito.numeroSolicitud;
            html += "<br><b>Le recordamos que su solicitud está en tramite, se le avisará por este medio </b>";
            html += "<br><b>No responda este correo porque fue generado de forma automatica.";
            html += "<br>Plataforma web CreditFullSA CR.</b>";

            Email email = new Email();
            email.Enviar(credito, html);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Aprobar(string Email, int id)
        {
            var temp = await _context.Creditos.FirstOrDefaultAsync(r => r.email == Email && r.numeroSolicitud == id);
            if (temp != null)
            {
                string html = "Bienvenidos a CreditFullSA web CR gracias por formar parte " +
        "de nuestra plataforma.<br>A continuación detallamos los datos de su credito solicitado " +
        "en nuestra plataforma web:";
                html += "<br><b>Su tramite fue ACEPTADO</b>";
                html += "<br><b>No responda este correo porque fue generado de forma automatica.";
                html += "<br>Plataforma web CreditFullSA CR.</b>";

                Email email = new Email();
                email.Enviar(temp, html);
                temp.estado = 'A';
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Rechazar(string Email, int id)
        {
            var temp = await _context.Creditos.FirstOrDefaultAsync(r => r.email == Email && r.numeroSolicitud == id);
            if (temp != null)
            {
                string html = "Bienvenidos a CreditFullSA web CR gracias por formar parte " +
       "de nuestra plataforma.<br>A continuación detallamos los datos de su credito solicitado " +
       "en nuestra plataforma web:";
                html += "<br><b>Su tramite fue RECHAZADA</b>";
                html += "<br><b>No responda este correo porque fue generado de forma automatica.";
                html += "<br>Plataforma web CreditFullSA CR.</b>";

                Email email = new Email();
                email.Enviar(temp, html);
                temp.estado = 'R';
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
