using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.UI.RuntimeTests.Helpers;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using static Private.Infrastructure.TestServices;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Media_Animation
{
	[TestClass]
	[RunsOnUIThread]
	public class Given_ColorAnimationUsingKeyFrames
	{
		[TestMethod]
		public async Task When_Theme_Changed_Animated_Value()
		{
			var page = new TestPages.ColorAnimationPage();
			WindowHelper.WindowContent = page;
			await WindowHelper.WaitForLoaded(page);
			await WindowHelper.WaitForIdle();

			Assert.AreEqual(Colors.Green, (page.Rect3.Fill as SolidColorBrush).Color);
			Assert.AreEqual(Colors.Green, (page.Rect4.Fill as SolidColorBrush).Color);

			using (ThemeHelper.UseDarkTheme())
			{
				await WindowHelper.WaitForIdle();
				
				Assert.AreEqual(Colors.Blue, (page.Rect3.Fill as SolidColorBrush).Color);
				Assert.AreEqual(Colors.Blue, (page.Rect4.Fill as SolidColorBrush).Color);
			}
		}
	}
}
