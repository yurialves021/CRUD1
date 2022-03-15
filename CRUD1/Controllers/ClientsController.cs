using CRUD1.Models;
using CRUD1.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD1.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            var clients = _clientRepository.Clients.ToList();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var client = _clientRepository.getClientById(id);
            return View(client);
        }
        [HttpPost]
        public IActionResult Create(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientRepository.addClient(client);
                    TempData["MensagemSucesso"] = "Success !!";

                    return RedirectToAction("Index");
                }
                return View(client);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = "Failed:" + e.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Update(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientRepository.UpdateClient(client);
                    TempData["MensagemSucesso"] = "Success !!";

                    return RedirectToAction("Index");
                }
                return View(client);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = "Failed:" + e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {

            var client = _clientRepository.getClientById(id);
            return View(client);
        }

        public IActionResult Remove(int id)
        {
            try
            {

                _clientRepository.RemoveClient(id);
                TempData["MensagemSucesso"] = "Success !!";

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = "Failed:" + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
