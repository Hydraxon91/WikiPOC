export interface WikiPage {
  id: string;
  title?: string;
  content?: string;
  siteSub?: string;
  roleNote?: string;
  categoryId?: string;
  category?: Category;
  paragraphs?: Paragraph[];
}

export interface Category {
  id: string;
  categoryName?: string;
  wikiPages?: WikiPage[];
}

export interface Paragraph {
  id: string;
  title?: string;
  content?: string;
  wikiPageId?: string;
}
