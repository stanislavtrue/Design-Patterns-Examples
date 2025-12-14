using System;
using System.Xml.Linq;

class EditorMemento
{
    public string Text { get; }
    
    public EditorMemento(string text)
    {
        Text = text;
    }
}

class TextEditor
{
    public string Text { get; private set; }
    
    public void AddText(string newText)
    {
        Text += newText;
    }
    
    public EditorMemento Save()
    {
        return new EditorMemento(Text);
    }
    
    public void ShowText()
    {
        Console.WriteLine(Text);
    }
    
    public void Restore(EditorMemento memento)
    {
        Text = memento.Text;
    }
}

class History
{
    private Stack<EditorMemento> history = new Stack<EditorMemento>();
    
    public void Save(EditorMemento memento) => history.Push(memento);
    
    public EditorMemento Undo() => history.Pop();
}

class Program
{
    static void Main(string[] args)
    {
        TextEditor textEditor = new TextEditor();
        History history = new History();
        history.Save(textEditor.Save());
        
        textEditor.AddText("The first text.");
        textEditor.ShowText();
        history.Save(textEditor.Save());
        
        textEditor.AddText(" The second text.");
        textEditor.ShowText();
        history.Save(textEditor.Save());
        
        textEditor.AddText(" The third text.");
        textEditor.ShowText(); 
        textEditor.Restore(history.Undo());
        textEditor.ShowText();
    }
}
