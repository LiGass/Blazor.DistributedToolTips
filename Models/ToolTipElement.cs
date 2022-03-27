using System;

namespace DistributedToolTips.Models
{
	public abstract class ToolTipElementModel
	{
		protected IToolTipState _container;
		protected ToolTipType _type;
		public ToolTipElementModel(IToolTipState stateContainer)
		{
			_container = stateContainer;
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
			return HashCode.Combine(_type);
		}
	}
	public class ToolTipTogglerModel : ToolTipElementModel
	{
		public ToolTipTogglerModel(IToolTipState stateContainer) : base(stateContainer)
		{
			_type = ToolTipType.Toggler;
		}

		public void ActivateToolTip()
		{
			_container.ActivateToolTip();
		}
		public override string GetCssClass()
		{
			return base.GetCssClass() + (_container.IsActive ? " ToolTips-Active" : " ToolTips-Hidden");
		}
	}
	public class ToolTipAnchorModel : ToolTipElementModel
	{
		public ToolTipAnchorModel(IToolTipState stateContainer) : base(stateContainer)
		{
			_type = ToolTipType.Anchor;
		}
		public override string GetCssClass()
		{
			return base.GetCssClass() + (_container.IsActive ? " ToolTips-Active" : " ToolTips-Hidden");
		}

	}
	public class ToolTipContainerModel : ToolTipElementModel
	{
		public ToolTipContainerModel(IToolTipState stateContainer) : base(stateContainer)
		{
			_type = ToolTipType.Container;
		}
		public override string GetCssClass()
		{
			return base.GetCssClass() + (_container.IsActive ? " Containers-Active" : " Container-Hidden");
		}

	}
	public enum ToolTipType
	{
		Anchor,
		Container,
		Toggler,
	}
}
