using BeezyApp.ViewModels;

namespace BeezyApp.View;

public partial class ChatView : ContentPage
{
	public ChatView(ChatVeiwModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}