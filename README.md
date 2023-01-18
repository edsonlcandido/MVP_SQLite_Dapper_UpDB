# MVP_SQLite_Dapper_UpDB

This project I create to study about software development using C# language with winforms, MVP pattern, SQLite with Dapper, and for control version of database I used DbUp.

I used a chatGPT talk to guide me in this project, conversation is in file [ChatGPT.md](./ChatGPT.md) (conversation in portuguese)

## Create database

First I create a commamd argument in my executable, when run .exe in console with arguments 'updb migrate' the database will be create by updb.

### Update database

I create a more two .sql files to know that updates via updb library, this show me how it works and give me a insight to crea a executable console application with argument to copy to all my future projects with Sqlite.

## Create Usuario

After I create the first CRUD operation implements MVP pattern like chat GPT show me in th conversation.

At this point I read about MVP pro features, like easy way to test the events with need a form, I ask to chat GPT how do this in MVP, he show me codes below:

```C#

[TestClass]
public class PresenterTests
{
    private IView _mockView;
    private Presenter _presenter;

    [TestInitialize]
    public void Setup()
    {
        _mockView = new MockView();
        _presenter = new Presenter(_mockView);
    }

    [TestMethod]
    public void ButtonClicked_ShouldUpdateTextBoxValue()
    {
        // Arrange
        _mockView.TextBoxValue = "Initial Text";

        // Act
        _mockView.RaiseButtonClickEvent();

        // Assert
        Assert.AreEqual("Button Clicked: Initial Text", _mockView.TextBoxValue);
    }
}

```

```C#

public class MockView : IView
{
    public string TextBoxValue { get; set; }
    public event EventHandler ButtonClick;

    public void RaiseButtonClickEvent()
    {
        ButtonClick?.Invoke(this, EventArgs.Empty);
    }
}

```

I like these way I will implement in future on my app.
