package md5ddf4cb079dbbbe2098903f1bec1fa4b8;


public class LeftoverSearchViewActivity
	extends md50f0aeb936ae9eba09430d28c4347cc0f.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TestRecipeApp.Views.Activities.LeftoverSearchViewActivity, TestRecipeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LeftoverSearchViewActivity.class, __md_methods);
	}


	public LeftoverSearchViewActivity ()
	{
		super ();
		if (getClass () == LeftoverSearchViewActivity.class)
			mono.android.TypeManager.Activate ("TestRecipeApp.Views.Activities.LeftoverSearchViewActivity, TestRecipeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
