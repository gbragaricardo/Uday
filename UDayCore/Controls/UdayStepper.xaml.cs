namespace UDayCore.Controls;

public partial class UdayStepper : ContentView
{
    public UdayStepper()
    {
        InitializeComponent();
    }

    // A propriedade que guarda o valor atual (Two-Way para atualizar a sua ViewModel)
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        propertyName: nameof(Value),
        returnType: typeof(int),
        declaringType: typeof(UdayStepper),
        defaultValue: 0,
        defaultBindingMode: BindingMode.TwoWay);

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    // Propriedades para configurar os limites e o salto
    public int Minimum { get; set; } = 0;
    public int Maximum { get; set; } = 100;
    public int Increment { get; set; } = 1;


    private void OnMinusClicked(object sender, EventArgs e)
    {
        if (Value - Increment >= Minimum)
        {
            Value -= Increment;
        }
    }

    private void OnPlusClicked(object sender, EventArgs e)
    {
        if (Value + Increment <= Maximum)
        {
            Value += Increment;
        }
    }
}