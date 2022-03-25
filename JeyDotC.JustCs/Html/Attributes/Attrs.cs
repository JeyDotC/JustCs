using JeyDotC.JustCs.Html.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeyDotC.JustCs.Html.Attributes
{
    /// <summary>
    /// This is a convenience class that serves as a dictionary for ALL known
    /// HTML attributes.
    /// </summary>
    public record Attrs : IElementAttributes
    {
        /// <summary>
        /// Applies to: input.
        /// Specifies the types of files that the server accepts (only for type="file")
        /// </summary>
        public string Accept { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Specifies the character encodings that are to be used for the form submission
        /// </summary>
        [Attr(NameTransform.DashCase)]
        public string AcceptCharset { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies a shortcut key to activate/focus an element
        /// </summary>
        public string Accesskey { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Specifies where to send the form-data when a form is submitted
        /// </summary>
        public string Action { get; init; }
        /// <summary>
        /// Applies to: area, img, input.
        /// Specifies an alternate text when the original element fails to display
        /// </summary>
        public string Alt { get; init; }
        /// <summary>
        /// Applies to: All visible elements
        /// All properties in this object will be rendered as aria-* attributes.
        /// </summary>
        public AriaAttrs Aria { get; init; }
        /// <summary>
        /// Applies to: script.
        /// Specifies that the script is executed asynchronously (only for external scripts)
        /// </summary>
        public bool? Async { get; init; }
        /// <summary>
        /// Applies to: form, input.
        /// Specifies whether the form or the input element should have autocomplete enabled
        /// </summary>
        public AutoCompleteValues? Autocomplete { get; init; }
        /// <summary>
        /// Applies to: button, input, select, textarea.
        /// Specifies that the element should automatically get focus when the page loads
        /// </summary>
        public bool? Autofocus { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Specifies that the audio/video will start playing as soon as it is ready
        /// </summary>
        public bool? Autoplay { get; init; }
        /// <summary>
        /// Applies to: meta, script.
        /// Specifies the character encoding
        /// </summary>
        public string Charset { get; init; }
        /// <summary>
        /// Applies to: input.
        /// Specifies that an input element should be pre-selected when the page loads (for type="checkbox" or type="radio")
        /// </summary>
        public bool? Checked { get; init; }
        /// <summary>
        /// Applies to: blockquote, del, ins, q.
        /// Specifies a URL which explains the quote/deleted/inserted text
        /// </summary>
        public string Cite { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies one or more classnames for an element (refers to a class in a style sheet)
        /// </summary>
        public string Class { get; init; }
        /// <summary>
        /// Applies to: textarea.
        /// Specifies the visible width of a text area
        /// </summary>
        public int? Cols { get; init; }
        /// <summary>
        /// Applies to: td, th.
        /// Specifies the number of columns a table cell should span
        /// </summary>
        public int? Colspan { get; init; }
        /// <summary>
        /// Applies to: meta.
        /// Gives the value associated with the http-equiv or name attribute
        /// </summary>
        public string Content { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies whether the content of an element is editable or not
        /// </summary>
        public bool? Contenteditable { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Specifies that audio/video controls should be displayed (such as a play/pause button etc)
        /// </summary>
        public bool? Controls { get; init; }
        /// <summary>
        /// Applies to: area.
        /// Specifies the coordinates of the area
        /// </summary>
        public string Coords { get; init; }
        /// <summary>
        /// Applies to: object.
        /// Specifies the URL of the resource to be used by the object
        /// </summary>
        public string Data { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Used to store custom data private to the page or application.
        /// All members of the given object will be rendered as data-* attributes
        /// converting their names from CamelCase to dash-case and their values
        /// to string. E.g. MyAttribute will become data-my-attribute.
        /// </summary>
        public object DataSet { get; init; }
        /// <summary>
        /// Applies to: del, ins, time.
        /// Specifies the date and time
        /// </summary>
        public string Datetime { get; init; }
        /// <summary>
        /// Applies to: track.
        /// Specifies that the track is to be enabled if the user's preferences do not indicate that another track would be more appropriate
        /// </summary>
        public bool? Default { get; init; }
        /// <summary>
        /// Applies to: script.
        /// Specifies that the script is executed when the page has finished parsing (only for external scripts)
        /// </summary>
        public bool? Defer { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies the text direction for the content in an element
        /// </summary>
        public DirValues? Dir { get; init; }
        /// <summary>
        /// Applies to: input, textarea.
        /// Specifies that the text direction will be submitted
        /// </summary>
        public string Dirname { get; init; }
        /// <summary>
        /// Applies to: button, fieldset, input, optgroup, option, select, textarea.
        /// Specifies that the specified element/group of elements should be disabled
        /// </summary>
        public bool? Disabled { get; init; }
        /// <summary>
        /// Applies to: a, area.
        /// Specifies that the target will be downloaded when a user clicks on the hyperlink
        /// </summary>
        public bool? Download { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies whether an element is draggable or not
        /// </summary>
        public BooleanValues? Draggable { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Specifies how the form-data should be encoded when submitting it to the server (only for method="post")
        /// </summary>
        public string Enctype { get; init; }
        /// <summary>
        /// Applies to: label, output.
        /// Specifies which form element(s) a label/calculation is bound to
        /// </summary>
        public string For { get; init; }
        /// <summary>
        /// Applies to: button, fieldset, input, label, meter, object, output, select, textarea.
        /// Specifies the name of the form the element belongs to
        /// </summary>
        public string Form { get; init; }
        /// <summary>
        /// Applies to: button, input.
        /// Specifies where to send the form-data when a form is submitted. Only for type="submit"
        /// </summary>
        public string Formaction { get; init; }
        /// <summary>
        /// Applies to: td, th.
        /// Specifies one or more headers cells a cell is related to
        /// </summary>
        public string Headers { get; init; }
        /// <summary>
        /// Applies to: canvas, embed, iframe, img, input, object, video.
        /// Specifies the height of the element
        /// </summary>
        public int? Height { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies that an element is not yet, or is no longer, relevant
        /// </summary>
        public bool? Hidden { get; init; }
        /// <summary>
        /// Applies to: meter.
        /// Specifies the range that is considered to be a high value
        /// </summary>
        public string High { get; init; }
        /// <summary>
        /// Applies to: a, area, base, link.
        /// Specifies the URL of the page the link goes to
        /// </summary>
        public string Href { get; init; }
        /// <summary>
        /// Applies to: a, area, link.
        /// Specifies the language of the linked document
        /// </summary>
        public string Hreflang { get; init; }
        /// <summary>
        /// Applies to: meta.
        /// Provides an HTTP header for the information/value of the content attribute
        /// </summary>
        [Attr(NameTransform.DashCase)]
        public string HttpEquiv { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies a unique id for an element
        /// </summary>
        public string Id { get; init; }
        /// <summary>
        /// Applies to: img.
        /// Specifies an image as a server-side image map
        /// </summary>
        public bool? Ismap { get; init; }
        /// <summary>
        /// Applies to: track.
        /// Specifies the kind of text track
        /// </summary>
        public string Kind { get; init; }
        /// <summary>
        /// Applies to: track, option, optgroup.
        /// Specifies the title of the text track
        /// </summary>
        public string Label { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies the language of the element's content
        /// </summary>
        public string Lang { get; init; }
        /// <summary>
        /// Applies to: input.
        /// Refers to a datalist element that contains pre-defined options for an input element
        /// </summary>
        public string List { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Specifies that the audio/video will start over again, every time it is finished
        /// </summary>
        public bool? Loop { get; init; }
        /// <summary>
        /// Applies to: meter.
        /// Specifies the range that is considered to be a low value
        /// </summary>
        public string Low { get; init; }
        /// <summary>
        /// Applies to: input, meter, progress.
        /// Specifies the maximum value
        /// </summary>
        public string Max { get; init; }
        /// <summary>
        /// Applies to: input, textarea.
        /// Specifies the maximum number of characters allowed in an element
        /// </summary>
        public int? Maxlength { get; init; }
        /// <summary>
        /// Applies to: a, area, link, source, style.
        /// Specifies what media/device the linked document is optimized for
        /// </summary>
        public string Media { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Specifies the HTTP method to use when sending form-data
        /// </summary>
        public string Method { get; init; }
        /// <summary>
        /// Applies to: input, meter.
        /// Specifies a minimum value
        /// </summary>
        public string Min { get; init; }
        /// <summary>
        /// Applies to: input, select.
        /// Specifies that a user can enter more than one value
        /// </summary>
        public bool? Multiple { get; init; }
        /// <summary>
        /// Applies to: video, audio.
        /// Specifies that the audio output of the video should be muted
        /// </summary>
        public bool? Muted { get; init; }
        /// <summary>
        /// Applies to: button, fieldset, form, iframe, input, map, meta, object, output, param, select, textarea.
        /// Specifies the name of the element
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Specifies that the form should not be validated when submitted
        /// </summary>
        public bool? Novalidate { get; init; }

        #region Event Listeners
        /// <summary>
        /// Applies to: audio, embed, img, object, video.
        /// Script to be run on abort
        /// </summary>
        public string Onabort { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run after the document is printed
        /// </summary>
        public string Onafterprint { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run before the document is printed
        /// </summary>
        public string Onbeforeprint { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when the document is about to be unloaded
        /// </summary>
        public string Onbeforeunload { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element loses focus
        /// </summary>
        public string Onblur { get; init; }
        /// <summary>
        /// Applies to: audio, embed, object, video.
        /// Script to be run when a file is ready to start playing (when it has buffered enough to begin)
        /// </summary>
        public string Oncanplay { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when a file can be played all the way to the end without pausing for buffering
        /// </summary>
        public string Oncanplaythrough { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the value of the element is changed
        /// </summary>
        public string Onchange { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element is being clicked
        /// </summary>
        public string Onclick { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a context menu is triggered
        /// </summary>
        public string Oncontextmenu { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the content of the element is being copied
        /// </summary>
        public string Oncopy { get; init; }
        /// <summary>
        /// Applies to: track.
        /// Script to be run when the cue changes in a track element
        /// </summary>
        public string Oncuechange { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the content of the element is being cut
        /// </summary>
        public string Oncut { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element is being double-clicked
        /// </summary>
        public string Ondblclick { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element is being dragged
        /// </summary>
        public string Ondrag { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run at the end of a drag operation
        /// </summary>
        public string Ondragend { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when an element has been dragged to a valid drop target
        /// </summary>
        public string Ondragenter { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when an element leaves a valid drop target
        /// </summary>
        public string Ondragleave { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when an element is being dragged over a valid drop target
        /// </summary>
        public string Ondragover { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run at the start of a drag operation
        /// </summary>
        public string Ondragstart { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when dragged element is being dropped
        /// </summary>
        public string Ondrop { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the length of the media changes
        /// </summary>
        public string Ondurationchange { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when something bad happens and the file is suddenly unavailable (like unexpectedly disconnects)
        /// </summary>
        public string Onemptied { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the media has reach the end (a useful event for messages like "thanks for listening")
        /// </summary>
        public string Onended { get; init; }
        /// <summary>
        /// Applies to: audio, body, embed, img, object, script, style, video.
        /// Script to be run when an error occurs
        /// </summary>
        public string Onerror { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element gets focus
        /// </summary>
        public string Onfocus { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when there has been changes to the anchor part of the a URL
        /// </summary>
        public string Onhashchange { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element gets user input
        /// </summary>
        public string Oninput { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element is invalid
        /// </summary>
        public string Oninvalid { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a user is pressing a key
        /// </summary>
        public string Onkeydown { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a user presses a key
        /// </summary>
        public string Onkeypress { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a user releases a key
        /// </summary>
        public string Onkeyup { get; init; }
        /// <summary>
        /// Applies to: body, iframe, img, input, link, script, style.
        /// Script to be run when the element is finished loading
        /// </summary>
        public string Onload { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when media data is loaded
        /// </summary>
        public string Onloadeddata { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when meta data (like dimensions and duration) are loaded
        /// </summary>
        public string Onloadedmetadata { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run just as the file begins to load before anything is actually loaded
        /// </summary>
        public string Onloadstart { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a mouse button is pressed down on an element
        /// </summary>
        public string Onmousedown { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run as long as the  mouse pointer is moving over an element
        /// </summary>
        public string Onmousemove { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a mouse pointer moves out of an element
        /// </summary>
        public string Onmouseout { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a mouse pointer moves over an element
        /// </summary>
        public string Onmouseover { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a mouse button is released over an element
        /// </summary>
        public string Onmouseup { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when a mouse wheel is being scrolled over an element
        /// </summary>
        public string Onmousewheel { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when the browser starts to work offline
        /// </summary>
        public string Onoffline { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when the browser starts to work online
        /// </summary>
        public string Ononline { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when a user navigates away from a page
        /// </summary>
        public string Onpagehide { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when a user navigates to a page
        /// </summary>
        public string Onpageshow { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the user pastes some content in an element
        /// </summary>
        public string Onpaste { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the media is paused either by the user or programmatically
        /// </summary>
        public string Onpause { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the media has started playing
        /// </summary>
        public string Onplay { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the media has started playing
        /// </summary>
        public string Onplaying { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when the window's history changes.
        /// </summary>
        public string Onpopstate { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the browser is in the process of getting the media data
        /// </summary>
        public string Onprogress { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run each time the playback rate changes (like when a user switches to a slow motion or fast forward mode).
        /// </summary>
        public string Onratechange { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Script to be run when a reset button in a form is clicked.
        /// </summary>
        public string Onreset { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when the browser window is being resized.
        /// </summary>
        public string Onresize { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when an element's scrollbar is being scrolled
        /// </summary>
        public string Onscroll { get; init; }
        /// <summary>
        /// Applies to: input.
        /// Script to be run when the user writes something in a search field (for input="search")
        /// </summary>
        public string Onsearch { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the seeking attribute is set to false indicating that seeking has ended
        /// </summary>
        public string Onseeked { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the seeking attribute is set to true indicating that seeking is active
        /// </summary>
        public string Onseeking { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the element gets selected
        /// </summary>
        public string Onselect { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the browser is unable to fetch the media data for whatever reason
        /// </summary>
        public string Onstalled { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when a Web Storage area is updated
        /// </summary>
        public string Onstorage { get; init; }
        /// <summary>
        /// Applies to: form.
        /// Script to be run when a form is submitted
        /// </summary>
        public string Onsubmit { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when fetching the media data is stopped before it is completely loaded for whatever reason
        /// </summary>
        public string Onsuspend { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the playing position has changed (like when the user fast forwards to a different point in the media)
        /// </summary>
        public string Ontimeupdate { get; init; }
        /// <summary>
        /// Applies to: details.
        /// Script to be run when the user opens or closes the details element
        /// </summary>
        public string Ontoggle { get; init; }
        /// <summary>
        /// Applies to: body.
        /// Script to be run when a page has unloaded (or the browser window has been closed)
        /// </summary>
        public string Onunload { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run each time the volume of a video/audio has been changed
        /// </summary>
        public string Onvolumechange { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Script to be run when the media has paused but is expected to resume (like when the media pauses to buffer more data)
        /// </summary>
        public string Onwaiting { get; init; }
        /// <summary>
        /// Applies to: All visible elements.
        /// Script to be run when the mouse wheel rolls up or down over an element
        /// </summary>
        public string Onwheel { get; init; }
        #endregion
        
        /// <summary>
        /// Applies to: details.
        /// Specifies that the details should be visible (open) to the user
        /// </summary>
        public bool? Open { get; init; }
        /// <summary>
        /// Applies to: meter.
        /// Specifies what value is the optimal value for the gauge
        /// </summary>
        public string Optimum { get; init; }
        /// <summary>
        /// Applies to: input.
        /// Specifies a regular expression that an input element's value is checked against
        /// </summary>
        public string Pattern { get; init; }
        /// <summary>
        /// Applies to: input, textarea.
        /// Specifies a short hint that describes the expected value of the element
        /// </summary>
        public string Placeholder { get; init; }
        /// <summary>
        /// Applies to: video.
        /// Specifies an image to be shown while the video is downloading, or until the user hits the play button
        /// </summary>
        public string Poster { get; init; }
        /// <summary>
        /// Applies to: audio, video.
        /// Specifies if and how the author thinks the audio/video should be loaded when the page loads
        /// </summary>
        public PreLoadValues? Preload { get; init; }
        /// <summary>
        /// Applies to: input, textarea.
        /// Specifies that the element is read-only
        /// </summary>
        public bool? Readonly { get; init; }
        /// <summary>
        /// Applies to: a, area, form, link.
        /// Specifies the relationship between the current document and the linked document
        /// </summary>
        public string Rel { get; init; }
        /// <summary>
        /// Applies to: input, select, textarea.
        /// Specifies that the element must be filled out before submitting the form
        /// </summary>
        public bool? Required { get; init; }
        /// <summary>
        /// Applies to: ol.
        /// Specifies that the list order should be descending (9,8,7..)
        /// </summary>
        public bool? Reversed { get; init; }
        /// <summary>
        /// Applies to: All visible elements
        /// Specifies this element's role according to WAI ARIA specs.
        /// </summary>
        public AriaRoles? Role { get; init; }
        /// <summary>
        /// Applies to: textarea.
        /// Specifies the visible number of lines in a text area
        /// </summary>
        public int? Rows { get; init; }
        /// <summary>
        /// Applies to: td, th.
        /// Specifies the number of rows a table cell should span
        /// </summary>
        public int? Rowspan { get; init; }
        /// <summary>
        /// Applies to: iframe.
        /// Enables an extra set of restrictions for the content in an iframe
        /// </summary>
        public bool? Sandbox { get; init; }
        /// <summary>
        /// Applies to: th.
        /// Specifies whether a header cell is a header for a column, row, or group of columns or rows
        /// </summary>
        public ScopeValues? Scope { get; init; }
        /// <summary>
        /// Applies to: option.
        /// Specifies that an option should be pre-selected when the page loads
        /// </summary>
        public bool? Selected { get; init; }
        /// <summary>
        /// Applies to: area.
        /// Specifies the shape of the area
        /// </summary>
        public ShapeValues? Shape { get; init; }
        /// <summary>
        /// Applies to: input, select.
        /// Specifies the width, in characters (for input) or specifies the number of visible options (for select)
        /// </summary>
        public int? Size { get; init; }
        /// <summary>
        /// Applies to: img, link, source.
        /// Specifies the size of the linked resource
        /// </summary>
        public string Sizes { get; init; }
        /// <summary>
        /// Applies to: col, colgroup.
        /// Specifies the number of columns to span
        /// </summary>
        public int? Span { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies whether the element is to have its spelling and grammar checked or not
        /// </summary>
        public BooleanValues? Spellcheck { get; init; }
        /// <summary>
        /// Applies to: audio, embed, iframe, img, input, script, source, track, video.
        /// Specifies the URL of the media file
        /// </summary>
        public string Src { get; init; }
        /// <summary>
        /// Applies to: iframe.
        /// Specifies the HTML content of the page to show in the iframe
        /// </summary>
        public string Srcdoc { get; init; }
        /// <summary>
        /// Applies to: track.
        /// Specifies the language of the track text data (required if kind="subtitles")
        /// </summary>
        public string Srclang { get; init; }
        /// <summary>
        /// Applies to: img, source.
        /// Specifies the URL of the image to use in different situations
        /// </summary>
        public string Srcset { get; init; }
        /// <summary>
        /// Applies to: ol.
        /// Specifies the start value of an ordered list
        /// </summary>
        public int? Start { get; init; }
        /// <summary>
        /// Applies to: input.
        /// Specifies the legal number intervals for an input field
        /// </summary>
        public string Step { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies an inline CSS style for an element
        /// </summary>
        public string Style { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies the tabbing order of an element
        /// </summary>
        public int? Tabindex { get; init; }
        /// <summary>
        /// Applies to: a, area, base, form.
        /// Specifies the target for where to open the linked document or where to submit the form
        /// </summary>
        public TargetValues? Target { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies extra information about an element
        /// </summary>
        public string Title { get; init; }
        /// <summary>
        /// Applies to: All Elements.
        /// Specifies whether the content of an element should be translated or not
        /// </summary>
        public TranslateValues? Translate { get; init; }
        /// <summary>
        /// Applies to: a, button, embed, input, link, menu, object, script, source, style.
        /// Specifies the type of element
        /// </summary>
        public string Type { get; init; }
        /// <summary>
        /// Applies to: img, object.
        /// Specifies an image as a client-side image map
        /// </summary>
        public string Usemap { get; init; }
        /// <summary>
        /// Applies to: button, input, li, option, meter, progress, param.
        /// Specifies the value of the element
        /// </summary>
        public string Value { get; init; }
        /// <summary>
        /// Applies to: canvas, embed, iframe, img, input, object, video.
        /// Specifies the width of the element
        /// </summary>
        public int? Width { get; init; }
        /// <summary>
        /// Applies to: textarea.
        /// Specifies how the text in a text area is to be wrapped when submitted in a form
        /// </summary>
        public WrapValues? Wrap { get; init; }

        /// <summary>
        /// Set an object to this property to add any attribute that is not part
        /// of the ones above. Properties in this object will be converted to
        /// dash-case and their values converted to string. E.g. MyArbitraryProperty
        /// will be rendered as my-arbitrary-property
        /// </summary>
        public object _ { get; init; }

        #region Obsolete Attributes
        /// <summary>
        /// Applies to: Not supported in HTML 5.
        /// Specifies the alignment according to surrounding elements. Use CSS instead
        /// </summary>
        [Obsolete("This attribute should not be used in modern HTML, left here for compatibility", false)]
        public string Align { get; init; }
        /// <summary>
        /// Applies to: Not supported in HTML 5.
        /// Specifies the background color of an element. Use CSS instead
        /// </summary>
        [Obsolete("This attribute should not be used in modern HTML, left here for compatibility", false)]
        public string Bgcolor { get; init; }
        /// <summary>
        /// Applies to: Not supported in HTML 5.
        /// Specifies the width of the border of an element. Use CSS instead
        /// </summary>
        [Obsolete("This attribute should not be used in modern HTML, left here for compatibility", false)]
        public string Border { get; init; }
        /// <summary>
        /// Applies to: Not supported in HTML 5.
        /// Specifies the text color of an element. Use CSS instead
        /// </summary>
        [Obsolete("This attribute should not be used in modern HTML, left here for compatibility", false)]
        public string Color { get; init; }
        #endregion

    }
}
