I use MudBlazor to quickly make web UIs.

**Document's MudBlazor Provides:**

- [Getting Started Docs](https://www.mudblazor.com/getting-started/installation#prerequisites)
- [Layouts](https://www.mudblazor.com/getting-started/layouts#navigation-menu)
- [Wireframes](https://www.mudblazor.com/getting-started/wireframes#main-layouts)
- [Theme Switcher](https://www.mudblazor.com/customization/overview#scrollbar)

## Why Use MudBlazor?

Originally, I was avoiding using it. Trying to get UI to do exactly what you want is always confusing when you didn't
write it.

The issue with writing my own UI was that the UI I wrote was awful. It wasn't design to work well with reuse and
testability.

So that's why I am using MudBlazor, it's better then what I wrote. And should it ever not do what I want, then I can
make brand
new UI and use MudBlazor design as a guide, rather than trying to force MudBlazor up to do and look how I want.

## Markdown Problem

MudBlazor needs to play nicely with loaded text from Markdown. 

![Markdown](pages/techstack/mudblazor/markdown.png)

![Rendered Markdown](pages/techstack/mudblazor/render.png)

```razor
@((MarkupString)Markdown.ToHtml(_content, MarkdownUtils.Pipeline))
```

The text looks awful when loaded as-is: MudBlazor removes the bulletin points on the unordered list, and it's all quite squished together without using more CSS theming.

