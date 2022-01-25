using System;
namespace JeyDotC.JustCs.Html.Attributes
{
    public class AriaAttrs
    {
        /// <summary>
        /// Identifies the currently active descendant of a composite widget.
        /// </summary>
        public string Activedescendant { get; init; }

        /// <summary>
        /// Indicates whether assistive technologies will present all, or only parts of, the changed region based on the change notifications defined by the aria-relevant attribute. See related aria-relevant.
        /// </summary>
        public BooleanValues? Atomic { get; init; }

        /// <summary>
        /// Indicates whether user input completion suggestions are provided.
        /// </summary>
        public AriaAutoCompleteValues? Autocomplete { get; init; }

        /// <summary>
        /// Indicates whether an element, and its subtree, are currently being updated.
        /// </summary>
        public BooleanValues? Busy { get; init; }

        /// <summary>
        /// Indicates the current "checked" state of checkboxes, radio buttons, and other widgets. See related aria-pressed and aria-selected.
        /// </summary>
        public TriState? Checked { get; init; }

        /// <summary>
        /// Identifies the element (or elements) whose contents or presence are controlled by the current element. See related aria-owns.
        /// </summary>
        public string Controls { get; init; }

        /// <summary>
        /// Identifies the element (or elements) that describes the object. See related aria-labelledby.
        /// </summary>
        public string Describedby { get; init; }

        /// <summary>
        /// Indicates that the element is perceivable but disabled, so it is not editable or otherwise operable. See related aria-hidden and aria-readonly.
        /// </summary>
        public BooleanValues? Disabled { get; init; }

        /// <summary>
        /// Indicates what functions can be performed when the dragged object is released on the drop target. This allows assistive technologies to convey the possible drag options available to users, including whether a pop-up menu of choices is provided by the application. Typically, drop effect functions can only be provided once an object has been grabbed for a drag operation as the drop effect functions available are dependent on the object being dragged.
        /// </summary>
        public AriaDropEffectValues? Dropeffect { get; init; }

        /// <summary>
        /// Indicates whether the element, or another grouping element it controls, is currently expanded or collapsed.
        /// </summary>
        public BooleanValues? Expanded { get; init; }

        /// <summary>
        /// Identifies the next element (or elements) in an alternate reading order of content which, at the user's discretion, allows assistive technology to override the general default of reading in document source order.
        /// </summary>
        public string Flowto { get; init; }

        /// <summary>
        /// Indicates an element's "grabbed" state in a drag-and-drop operation.
        /// </summary>
        public BooleanValues? Grabbed { get; init; }

        /// <summary>
        /// Indicates that the element has a popup context menu or sub-level menu.
        /// </summary>
        public BooleanValues? Haspopup { get; init; }

        /// <summary>
        /// Indicates that the element and all of its descendants are not visible or perceivable to any user as implemented by the author. See related aria-disabled.
        /// </summary>
        public BooleanValues? Hidden { get; init; }

        /// <summary>
        /// Indicates the entered value does not conform to the format expected by the application.
        /// </summary>
        public AriaInvalidValues? Invalid { get; init; }

        /// <summary>
        /// Defines a string value that labels the current element. See related aria-labelledby.
        /// </summary>
        public string Label { get; init; }

        /// <summary>
        /// Identifies the element (or elements) that labels the current element. See related aria-label and aria-describedby.
        /// </summary>
        public string Labelledby { get; init; }

        /// <summary>
        /// Defines the hierarchical level of an element within a structure.
        /// </summary>
        public int? Level { get; init; }

        /// <summary>
        /// Indicates that an element will be updated, and describes the types of updates the user agents, assistive technologies, and user can expect from the live region.
        /// </summary>
        public AriaLiveValues? Live { get; init; }

        /// <summary>
        /// Indicates whether a text box accepts multiple lines of input or only a single line.
        /// </summary>
        public BooleanValues? Multiline { get; init; }

        /// <summary>
        /// Indicates that the user may select more than one item from the current selectable descendants.
        /// </summary>
        public BooleanValues? Multiselectable { get; init; }

        /// <summary>
        /// Indicates whether the element and orientation is horizontal or vertical.
        /// </summary>
        public AriaOrientationValues? Orientation { get; init; }

        /// <summary>
        /// Identifies an element (or elements) in order to define a visual, functional, or contextual parent/child relationship between DOM elements where the DOM hierarchy cannot be used to represent the relationship. See related aria-controls.
        /// </summary>
        public string Owns { get; init; }

        /// <summary>
        /// Defines an element's number or position in the current set of listitems or treeitems. Not required if all elements in the set are present in the DOM. See related aria-setsize.
        /// </summary>
        public int? Posinset { get; init; }

        /// <summary>
        /// Indicates the current "pressed" state of toggle buttons. See related aria-checked and aria-selected.
        /// </summary>
        public TriState? Pressed { get; init; }

        /// <summary>
        /// Indicates that the element is not editable, but is otherwise operable. See related aria-disabled.
        /// </summary>
        public BooleanValues? Readonly { get; init; }

        /// <summary>
        /// Indicates what user agent change notifications (additions, removals, etc.) assistive technologies will receive within a live region. See related aria-atomic.
        /// </summary>
        public string Relevant { get; init; }

        /// <summary>
        /// Indicates that user input is required on the element before a form may be submitted.
        /// </summary>
        public BooleanValues? Required { get; init; }

        /// <summary>
        /// Indicates the current "selected" state of various widgets. See related aria-checked and aria-pressed.
        /// </summary>
        public BooleanValues? Selected { get; init; }

        /// <summary>
        /// Defines the number of items in the current set of listitems or treeitems. Not required if all elements in the set are present in the DOM. See related aria-posinset.
        /// </summary>
        public int? Setsize { get; init; }

        /// <summary>
        /// Indicates if items in a table or grid are sorted in ascending or descending order.
        /// </summary>
        public AriaSortValues? Sort { get; init; }

        /// <summary>
        /// Defines the maximum allowed value for a range widget.
        /// </summary>
        public float? Valuemax { get; init; }

        /// <summary>
        /// Defines the minimum allowed value for a range widget.
        /// </summary>
        public float? Valuemin { get; init; }

        /// <summary>
        /// Defines the current value for a range widget. See related aria-valuetext.
        /// </summary>
        public float? Valuenow { get; init; }

        /// <summary>
        /// Defines the human readable text alternative of aria-valuenow for a range widget.
        /// </summary>
        public string Valuetext { get; init; }

        private int? _generatedHashCode;

        public override bool Equals(object obj)
        {
            var otherAria = obj as AriaAttrs;

            if (otherAria == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Activedescendant == otherAria.Activedescendant &&
                Atomic == otherAria.Atomic &&
                Autocomplete == otherAria.Autocomplete &&
                Busy == otherAria.Busy &&
                Checked == otherAria.Checked &&
                Controls == otherAria.Controls &&
                Describedby == otherAria.Describedby &&
                Disabled == otherAria.Disabled &&
                Dropeffect == otherAria.Dropeffect &&
                Expanded == otherAria.Expanded &&
                Flowto == otherAria.Flowto &&
                Grabbed == otherAria.Grabbed &&
                Haspopup == otherAria.Haspopup &&
                Hidden == otherAria.Hidden &&
                Invalid == otherAria.Invalid &&
                Label == otherAria.Label &&
                Labelledby == otherAria.Labelledby &&
                Level == otherAria.Level &&
                Live == otherAria.Live &&
                Multiline == otherAria.Multiline &&
                Multiselectable == otherAria.Multiselectable &&
                Orientation == otherAria.Orientation &&
                Owns == otherAria.Owns &&
                Posinset == otherAria.Posinset &&
                Pressed == otherAria.Pressed &&
                Readonly == otherAria.Readonly &&
                Relevant == otherAria.Relevant &&
                Required == otherAria.Required &&
                Selected == otherAria.Selected &&
                Setsize == otherAria.Setsize &&
                Sort == otherAria.Sort &&
                Valuemax == otherAria.Valuemax &&
                Valuemin == otherAria.Valuemin &&
                Valuenow == otherAria.Valuenow &&
                Valuetext == otherAria.Valuetext;

        }

        public override int GetHashCode()
        {
            if (_generatedHashCode.HasValue)
            {
                return _generatedHashCode.Value;
            }

            _generatedHashCode = this.HeavyGenerateHashCode();

            return _generatedHashCode.Value;
        }
    }
}
