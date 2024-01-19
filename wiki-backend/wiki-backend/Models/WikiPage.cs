﻿using wiki_backend.Objects;

namespace wiki_backend.Models;

public class WikiPage
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SiteSub { get; set; }
    public string RoleNote { get; set; }
    public virtual ICollection<Paragraph> Paragraphs { get; set; } = new List<Paragraph>();
}