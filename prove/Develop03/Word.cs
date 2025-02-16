class Word
{
    private string _text;
    private bool _isHidden;

    public bool IsHidden
    {
        get { return _isHidden; }
        private set { _isHidden = value; }
    }

    public string Text
    {
        get { return _text; }
        private set { _text = value; }
    }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}
