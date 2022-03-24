using System;

namespace ToolTips.Models
{
	public abstract class ToolTipElementModel
	{
		protected IToolTipState _container;
		protected ToolTipType _type;
		protected string _id;
		public ToolTipElementModel(IToolTipState stateContainer, string identifier)
		{
			_container = stateContainer;
			_id = identifier;
		}
		public void SetStateContainer(IToolTipState container)
		{
			if (_container == null) { throw new ArgumentNullException(nameof(container), "A ToolTipState Component must be implemented."); }
			_container = container;
		}
		public string GetToolTipType() { return _type.ToString(); }
		public virtual string GetCssClass()
		{
			return $"ToolTip-{GetToolTipType()}";
		}
		public override bool Equals(object obj)
		{
			if (obj is ToolTipElementModel tooltip)
			{
				return tooltip.GetHashCode() == GetHashCode();
			}
			return false;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(_type, _id);
		}
	}
	public class ToolTipTogglerModel : ToolTipElementModel
	{
		public ToolTipTogglerModel(IToolTipState stateContainer, string identifier) : base(stateContainer, identifier)
		{
			_type = ToolTipType.Toggler;
		}

		public void ActivateToolTip()
		{
			_container.ActivateToolTip();
		}
		public override string GetCssClass()
		{
			return base.GetCssClass() + (_container.IsActive ? " Toggler-On" : " Toggler-Off");
		}
	}
	public class ToolTipAnchorModel : ToolTipElementModel
	{
		public ToolTipAnchorModel(IToolTipState stateContainer, string identifier) : base(stateContainer, identifier)
		{
			_type = ToolTipType.Anchor;
		}
		public override string GetCssClass()
		{
			return base.GetCssClass() + (_container.IsActive ? " ToolTip-Displayed" : " ToolTip-Hidden");
		}

	}
	public class ToolTipContainerModel : ToolTipElementModel
	{
		public ToolTipContainerModel(IToolTipState stateContainer, string identifier) : base(stateContainer, identifier)
		{
			_type = ToolTipType.Container;
		}
		public override string GetCssClass()
		{
			return base.GetCssClass() + (_container.IsActive ? " Container-Displayed" : " Container-Hidden");
		}

	}
	public enum ToolTipType
	{
		Anchor,
		Container,
		Toggler,
	}
}
