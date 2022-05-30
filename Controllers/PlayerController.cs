using Microsoft.AspNetCore.Mvc;
using RPGame.Model;
using RPGame.Services;

namespace RPGame.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private IPlayer _playerService;
    private Enemy enemy = Enemy.Instance;

    public PlayerController(ILogger<PlayerController> logger, IPlayer playerService)
    {
        _logger = logger;
        _playerService = playerService;
    }


    [HttpGet("GetPlayerStatus")]
    public IActionResult GetPlayerStatus()
    {
        Player? player = _playerService.GetPlayer();
        if (player?.Id == 1)
        {
            return Ok(player);
        }
        return NotFound("Inicie um jogo para ver seu jogador.");
    }
    [HttpGet("GetEnemyStatus")]
    public IActionResult GetEnemyStatus()
    {
        if (enemy.Health > 0)
            return Ok(enemy);
        else
            return NotFound("Invoque um novo inimigo" + Environment.NewLine + "Um avatar vivo é necessário para invocar um inimigo!");
    }
    [HttpPost("StartNewGame/{name}")]
    public IActionResult StartNewGame(string name)
    {
        return Ok(_playerService.StartNewGame(name));
    }

    [HttpPost("InvokeEnemy")]
    public IActionResult NewEnemyInvoke()
    {
        InvokeEnemy();
        return Ok("Inimigo invocado");
    }


    [HttpPut("Attack")]
    public IActionResult Attack()
    {
        Player? player = _playerService.GetPlayer();
        if (player?.Id == 1)
        {
            if (enemy.Health <= 0) return Ok("Invoque um inimigo antes de atacar");
            player.Attack();
            if (player.Health <= 0)
            {
                _playerService.Delete();
                return Ok("Você morreu, obtenha um novo avatar");
            }
            _playerService.SavingGame(player);
            return Ok("Ataque realizado");
        }
        return NotFound("Crie um avatar antes de atacar.");
    }

    [HttpDelete("FinishGame")]
    public IActionResult FinishGame()
    {
        bool deleted = _playerService.Delete();
        if (deleted) return NoContent();
        return BadRequest("Nenhum jogo a ser deletado.");
    }


    private void InvokeEnemy()
    {
        Player? playerHolder = _playerService.GetPlayer();
        if (playerHolder != null)
            enemy.GenerateEnemyProperties(playerHolder.Strength, playerHolder.MaxHealth, playerHolder.Kills);
    }
}
