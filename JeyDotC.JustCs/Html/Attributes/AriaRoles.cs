using System;
namespace JeyDotC.JustCs.Html.Attributes
{
    public enum AriaRoles
    {
        /// <summary>
        /// A message with important, and usually time-sensitive, information. See related alertdialog and status.
        /// </summary>
        Alert,

        /// <summary>
        /// A type of dialog that contains an alert message, where initial focus goes to an element within the dialog. See related alert and dialog.
        /// </summary>
        Alertdialog,

        /// <summary>
        /// A region declared as a web application, as opposed to a web document.
        /// </summary>
        Application,

        /// <summary>
        /// A section of a page that consists of a composition that forms an independent part of a document, page, or site.
        /// </summary>
        Article,

        /// <summary>
        /// A region that contains mostly site-oriented content, rather than page-specific content.
        /// </summary>
        Banner,

        /// <summary>
        /// An input that allows for user-triggered actions when clicked or pressed. See related link.
        /// </summary>
        Button,

        /// <summary>
        /// A checkable input that has three possible values: true, false, or mixed.
        /// </summary>
        Checkbox,

        /// <summary>
        /// A cell containing header information for a column.
        /// </summary>
        Columnheader,

        /// <summary>
        /// A presentation of a select; usually similar to a textbox where users can type ahead to select an option, or type to enter arbitrary text as a new item in the list. See related listbox.
        /// </summary>
        Combobox,

        /// <summary>
        /// A form of widget that performs an action but does not receive input data.
        /// </summary>
        Command,

        /// <summary>
        /// A supporting section of the document, designed to be complementary to the main content at a similar level in the DOM hierarchy, but remains meaningful when separated from the main content.
        /// </summary>
        Complementary,

        /// <summary>
        /// A widget that may contain navigable descendants or owned children.
        /// </summary>
        Composite,

        /// <summary>
        /// A large perceivable region that contains information about the parent document.
        /// </summary>
        Contentinfo,

        /// <summary>
        /// A definition of a term or concept.
        /// </summary>
        Definition,

        /// <summary>
        /// A dialog is an application window that is designed to interrupt the current processing of an application in order to prompt the user to enter information or require a response. See related alertdialog.
        /// </summary>
        Dialog,

        /// <summary>
        /// A list of references to members of a group, such as a static table of contents.
        /// </summary>
        Directory,

        /// <summary>
        /// A region containing related information that is declared as document content, as opposed to a web application.
        /// </summary>
        Document,

        /// <summary>
        /// A landmark region that contains a collection of items and objects that, as a whole, combine to create a form. See related search.
        /// </summary>
        Form,

        /// <summary>
        /// A grid is an interactive control which contains cells of tabular data arranged in rows and columns, like a table.
        /// </summary>
        Grid,

        /// <summary>
        /// A cell in a grid or treegrid.
        /// </summary>
        Gridcell,

        /// <summary>
        /// A set of user interface objects which are not intended to be included in a page summary or table of contents by assistive technologies.
        /// </summary>
        Group,

        /// <summary>
        /// A heading for a section of the page.
        /// </summary>
        Heading,

        /// <summary>
        /// A container for a collection of elements that form an image.
        /// </summary>
        Img,

        /// <summary>
        /// A generic type of widget that allows user input.
        /// </summary>
        Input,

        /// <summary>
        /// A region of the page intended as a navigational landmark.
        /// </summary>
        Landmark,

        /// <summary>
        /// An interactive reference to an internal or external resource that, when activated, causes the user agent to navigate to that resource. See related button.
        /// </summary>
        Link,

        /// <summary>
        /// A group of non-interactive list items. See related listbox.
        /// </summary>
        List,

        /// <summary>
        /// A widget that allows the user to select one or more items from a list of choices. See related combobox and list.
        /// </summary>
        Listbox,

        /// <summary>
        /// A single item in a list or directory.
        /// </summary>
        Listitem,

        /// <summary>
        /// A type of live region where new information is added in meaningful order and old information may disappear. See related marquee.
        /// </summary>
        Log,

        /// <summary>
        /// The main content of a document.
        /// </summary>
        Main,

        /// <summary>
        /// A type of live region where non-essential information changes frequently. See related log.
        /// </summary>
        Marquee,

        /// <summary>
        /// Content that represents a mathematical expression.
        /// </summary>
        Math,

        /// <summary>
        /// A type of widget that offers a list of choices to the user.
        /// </summary>
        Menu,

        /// <summary>
        /// A presentation of menu that usually remains visible and is usually presented horizontally.
        /// </summary>
        Menubar,

        /// <summary>
        /// An option in a set of choices contained by a menu or menubar.
        /// </summary>
        Menuitem,

        /// <summary>
        /// A menuitem with a checkable state whose possible values are true, false, or mixed.
        /// </summary>
        Menuitemcheckbox,

        /// <summary>
        /// A checkable menuitem in a set of elements with role menuitemradio, only one of which can be checked at a time.
        /// </summary>
        Menuitemradio,

        /// <summary>
        /// A collection of navigational elements (usually links) for navigating the document or related documents.
        /// </summary>
        Navigation,

        /// <summary>
        /// A section whose content is parenthetic or ancillary to the main content of the resource.
        /// </summary>
        Note,

        /// <summary>
        /// A selectable item in a select list.
        /// </summary>
        Option,

        /// <summary>
        /// An element whose implicit native role semantics will not be mapped to the accessibility API.
        /// </summary>
        Presentation,

        /// <summary>
        /// An element that displays the progress status for tasks that take a long time.
        /// </summary>
        Progressbar,

        /// <summary>
        /// A checkable input in a group of radio roles, only one of which can be checked at a time.
        /// </summary>
        Radio,

        /// <summary>
        /// A group of radio buttons.
        /// </summary>
        Radiogroup,

        /// <summary>
        /// An input representing a range of values that can be set by the user.
        /// </summary>
        Range,

        /// <summary>
        /// A large perceivable section of a web page or document, that is important enough to be included in a page summary or table of contents, for example, an area of the page containing live sporting event statistics.
        /// </summary>
        Region,

        /// <summary>
        /// The base role from which all other roles in this taxonomy inherit.
        /// </summary>
        Roletype,

        /// <summary>
        /// A row of cells in a grid.
        /// </summary>
        Row,

        /// <summary>
        /// A group containing one or more row elements in a grid.
        /// </summary>
        Rowgroup,

        /// <summary>
        /// A cell containing header information for a row in a grid.
        /// </summary>
        Rowheader,

        /// <summary>
        /// A graphical object that controls the scrolling of content within a viewing area, regardless of whether the content is fully displayed within the viewing area.
        /// </summary>
        Scrollbar,

        /// <summary>
        /// A landmark region that contains a collection of items and objects that, as a whole, combine to create a search facility. See related form.
        /// </summary>
        Search,

        /// <summary>
        /// A renderable structural containment unit in a document or application.
        /// </summary>
        Section,

        /// <summary>
        /// A structure that labels or summarizes the topic of its related section.
        /// </summary>
        Sectionhead,

        /// <summary>
        /// A form widget that allows the user to make selections from a set of choices.
        /// </summary>
        Select,

        /// <summary>
        /// A divider that separates and distinguishes sections of content or groups of menuitems.
        /// </summary>
        Separator,

        /// <summary>
        /// A user input where the user selects a value from within a given range.
        /// </summary>
        Slider,

        /// <summary>
        /// A form of range that expects the user to select from among discrete choices.
        /// </summary>
        Spinbutton,

        /// <summary>
        /// A container whose content is advisory information for the user but is not important enough to justify an alert, often but not necessarily presented as a status bar. See related alert.
        /// </summary>
        Status,

        /// <summary>
        /// A document structural element.
        /// </summary>
        Structure,

        /// <summary>
        /// A grouping label providing a mechanism for selecting the tab content that is to be rendered to the user.
        /// </summary>
        Tab,

        /// <summary>
        /// A list of tab elements, which are references to tabpanel elements.
        /// </summary>
        Tablist,

        /// <summary>
        /// A container for the resources associated with a tab, where each tab is contained in a tablist.
        /// </summary>
        Tabpanel,

        /// <summary>
        /// Input that allows free-form text as its value.
        /// </summary>
        Textbox,

        /// <summary>
        /// A type of live region containing a numerical counter which indicates an amount of elapsed time from a start point, or the time remaining until an end point.
        /// </summary>
        Timer,

        /// <summary>
        /// A collection of commonly used function buttons or controls represented in compact visual form.
        /// </summary>
        Toolbar,

        /// <summary>
        /// A contextual popup that displays a description for an element.
        /// </summary>
        Tooltip,

        /// <summary>
        /// A type of list that may contain sub-level nested groups that can be collapsed and expanded.
        /// </summary>
        Tree,

        /// <summary>
        /// A grid whose rows can be expanded and collapsed in the same manner as for a tree.
        /// </summary>
        Treegrid,

        /// <summary>
        /// An option item of a tree. This is an element within a tree that may be expanded or collapsed if it contains a sub-level group of treeitem elements.
        /// </summary>
        Treeitem,

        /// <summary>
        /// An interactive component of a graphical user interface (GUI).
        /// </summary>
        Widget,

        /// <summary>
        /// A browser or application window.
        /// </summary>
        Window,
    }
}
