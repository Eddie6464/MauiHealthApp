namespace HealthApp;
using Microsoft.Maui.Graphics;

public partial class SpinnerPage : ContentPage
{

	public SpinnerPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private void OnBackClick(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

    private void OnLeftClick(object sender, EventArgs e)
	{
		StartCanvasRotationLeft();
	}

    private void OnRightClick(object sender, EventArgs e)
	{
		StartCanvasRotationRight();
	}

    private async void StartCanvasRotationRight()
        {
            //rotation animation for spinner
            var rotationAnimation = new Animation(v => Canvas.Rotation = v, 0, 3000);

            rotationAnimation.Easing = new Easing(t => 1 - Math.Pow(1 - t, 5));

            // loop the animation
            rotationAnimation.Commit(this, "SpinAnimation", length: 4000, repeat: () => false);
        }

    private async void StartCanvasRotationLeft()
        {
            //rotation animation for spinner
            var rotationAnimation = new Animation(v => Canvas.Rotation = v, 0, -3000);

            rotationAnimation.Easing = new Easing(t => 1 - Math.Pow(1 - t, 5));

            //loop the animation
            rotationAnimation.Commit(this, "SpinAnimation", length: 4000, repeat: () => false);
        }

}

public class MyFirstDrawing : IDrawable
{
    //drawing the shape of the spinner
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        PathF path = new PathF();
        path.MoveTo(654, 20); // starting point
        path.LineTo(598, 204);
        path.LineTo(499, 291);
        path.LineTo(427, 249);
        path.LineTo(457, 332);
        path.LineTo(654, 302);
        path.LineTo(771, 333);
        path.LineTo(790, 423);
        path.LineTo(832, 345);
        path.LineTo(709, 204);
        path.LineTo(678, 68);
        path.LineTo(747, 21);
        canvas.FillColor = Colors.SlateBlue;
        canvas.FillPath(path); 
    }
}

