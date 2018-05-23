package md50f0aeb936ae9eba09430d28c4347cc0f;


public class MySearchView
	extends android.support.v7.widget.SearchView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setOnQueryTextListener:(Landroid/support/v7/widget/SearchView$OnQueryTextListener;)V:GetSetOnQueryTextListener_Landroid_support_v7_widget_SearchView_OnQueryTextListener_Handler\n" +
			"";
		mono.android.Runtime.register ("TestRecipeApp.Utilites.MySearchView, TestRecipeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MySearchView.class, __md_methods);
	}


	public MySearchView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MySearchView.class)
			mono.android.TypeManager.Activate ("TestRecipeApp.Utilites.MySearchView, TestRecipeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public MySearchView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MySearchView.class)
			mono.android.TypeManager.Activate ("TestRecipeApp.Utilites.MySearchView, TestRecipeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public MySearchView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MySearchView.class)
			mono.android.TypeManager.Activate ("TestRecipeApp.Utilites.MySearchView, TestRecipeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void setOnQueryTextListener (android.support.v7.widget.SearchView.OnQueryTextListener p0)
	{
		n_setOnQueryTextListener (p0);
	}

	private native void n_setOnQueryTextListener (android.support.v7.widget.SearchView.OnQueryTextListener p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
