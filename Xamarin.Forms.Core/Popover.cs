using System;
using System.Threading.Tasks;

namespace Xamarin.Forms
{
	public abstract class Popover<T> 
	{
		public Popover(View view, string title = null, bool isLightDismissEnabled = true){
			View = view;
			Title = title;
			IsLightDismissEnabled = isLightDismissEnabled;

			tcs = new TaskCompletionSource<T>();
		}

		private TaskCompletionSource<T> tcs;

		public string Title { get; private set; }

		public bool IsLightDismissEnabled { get; private set; }

		public View View { get; private set; }

		public void Dismiss (T result)
		{
			throw new NotImplementedException();
		}

		public Task<T> Result 
		{ 
			get
			{
				return tcs.Task;
			} 
		}

		public void LightDismiss()
		{
			tcs.TrySetResult(OnLightDismissed());	
		}

		protected abstract T OnLightDismissed ();
	}

	public enum PopoverResult
	{
		Accepted,
		Rejected,
	}

	public class Popover : Popover<PopoverResult>
	{
		public Popover(View view, string title = null, bool isLightDismissEnabled = true)
			: base(view, title, isLightDismissEnabled)
		{
			
		}

		protected override PopoverResult OnLightDismissed () { return PopoverResult.Rejected; }
	}
}