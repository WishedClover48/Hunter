using UnityEngine;

internal class LoseCommand : ICommand
{
    private GameObject _player;
    public LoseCommand(GameObject player)
    {
        _player = player;
    }
    public void Execute()
    {
        _player.GetComponent<PlayerLives>().Kill();
    }
}