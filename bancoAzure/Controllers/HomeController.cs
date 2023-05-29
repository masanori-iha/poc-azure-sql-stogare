using bancoAzure.Interfaces;
using bancoAzure.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;

namespace bancoAzure.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IToastNotification _toastNotification;
    private readonly FileService _fileService;

    public HomeController(ILogger<HomeController> logger,
                          IUsuarioRepository usuarioRepository,
                          IToastNotification toastNotification,
                          FileService fileService)
    {
        _logger = logger;
        _usuarioRepository = usuarioRepository;
        _toastNotification = toastNotification;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioRepository.GetAll();

        return View(usuarios);
    }

    public IActionResult Alerta()
    {
        return Json(new { mensagem = "Masanori testando alerta" });
    }

    public IActionResult Adicionar()
    {
        return PartialView("Create");
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBodyAttribute] UsuarioCreate usuario)
    {
        try
        {
            await _usuarioRepository.Add(usuario);

            return Ok();
        }
        catch (Exception ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);

            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            await _usuarioRepository.Excluir(id);

            _toastNotification.AddSuccessToastMessage("Usuário excluído com sucesso");

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Upload(IList<IFormFile> files)
    {
        try
        {
            var result = await _fileService.UploadAsync(files[0]);

            _toastNotification.AddSuccessToastMessage("Arquivo salvo com sucesso");

            return Ok();
        }
        catch
        {
            _toastNotification.AddErrorToastMessage("Ops, ocorreu um erro...");

            return BadRequest();
        }
    }

    public async Task<IActionResult> ListarImagens()
    {
        var files = await _fileService.List();

        return PartialView("PartialBlobs", files);
    }

    public IActionResult ObterImagem(string uri)
    {
        return PartialView("PartialImagem", uri);
    }

    [HttpDelete]
    public async Task<IActionResult> Excluir(string nome)
    {
        try
        {
            await _fileService.Excluir(nome);

            _toastNotification.AddSuccessToastMessage("Arquivo excluído com sucesso");

            return Ok();
        }
        catch (Exception ex)
        {
            _toastNotification.AddErrorToastMessage($"Ops, ocorreu um erro...: {ex.Message}");

            return BadRequest();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}