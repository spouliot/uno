﻿using Uno.UI.Xaml.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.Xaml.Islands;

internal class XamlIslandRoot : Panel
{
	private readonly ContentRoot _contentRoot;

	internal XamlIslandRoot(CoreServices coreServices)
	{
		_contentRoot = coreServices.ContentRootCoordinator.CreateContentRoot(ContentRootType.XamlIsland, Colors.Transparent, this);

		//Uno specific - flag as VisualTreeRoot for interop with existing logic
		IsVisualTreeRoot = true;
	}

	internal ContentRoot ContentRoot => _contentRoot;

	internal void SetPublicRootVisual(UIElement uiElement)
	{
		_contentRoot.VisualTree.SetPublicRootVisual(uiElement, null, null);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		finalSize = base.ArrangeOverride(finalSize);
		Width = finalSize.Width;
		Height = finalSize.Height;
		return finalSize;	
	}
}
