using System;
using System.Xml.Serialization;
interface ICommand
{
    void Execute();
    void Undo();
}
class Player
{
    public void GoLeft() => Console.WriteLine("Going left...");
    public void GoRight() => Console.WriteLine("Going right...");
    public void GoUp() => Console.WriteLine("Going up...");
    public void GoDown() => Console.WriteLine("Going down...");
}
class GoLeftCommand : ICommand
{
    private Player _player;
    public GoLeftCommand(Player player) => _player = player;
    public void Execute() => _player.GoLeft();
    public void Undo() => _player.GoRight();
}
class GoRightCommand : ICommand
{
    private Player _player;
    public GoRightCommand(Player player) => _player = player;
    public void Execute() => _player.GoRight();
    public void Undo() => _player.GoLeft();
}
class GoUpCommand : ICommand
{
    private Player _player;
    public GoUpCommand(Player player) => _player = player;
    public void Execute() => _player.GoUp();
    public void Undo() => _player.GoDown();
}
class GoDownCommand : ICommand
{
    private Player _player;
    public GoDownCommand(Player player) => _player = player;
    public void Execute() => _player.GoDown();
    public void Undo() => _player.GoUp();
}
class GameController
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void PressButton() => _command.Execute();
    public void PressUndo() => _command.Undo();
}
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        ICommand playerDown = new GoDownCommand(player);
        ICommand playerUp = new GoUpCommand(player);
        ICommand playerleft = new GoLeftCommand(player);
        ICommand playerright = new GoRightCommand(player);
        GameController controller = new GameController();
        controller.SetCommand(playerUp);
        controller.PressButton();
        controller.SetCommand(playerleft);
        controller.PressButton();
    }
}