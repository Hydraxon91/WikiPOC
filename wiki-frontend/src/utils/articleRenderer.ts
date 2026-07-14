export interface ParagraphTitles {
  mainParagraphs: { id: string; text: string }[];
  subparagraphs: { id: string; mainId: string; text: string }[];
}

function decodeHtmlEntities(text: string): string {
  const textarea = document.createElement('textarea');
  textarea.innerHTML = text;
  return textarea.value;
}

export function extractParagraphTitles(htmlContent: string): ParagraphTitles {
  const mainRegex = /<h2>(.*?)<\/h2>/g;
  const subRegex = /<h3>(.*?)<\/h3>/g;
  const mainParagraphs: { id: string; text: string }[] = [];
  const subparagraphs: { id: string; mainId: string; text: string }[] = [];

  let mainMatch;
  while ((mainMatch = mainRegex.exec(htmlContent)) !== null) {
    const id = `main-${mainParagraphs.length + 1}`;
    mainParagraphs.push({ id, text: decodeHtmlEntities(mainMatch[1]) });
  }

  let subMatch;
  while ((subMatch = subRegex.exec(htmlContent)) !== null) {
    const subId = `sub-${subparagraphs.length + 1}`;
    let nearestMainIndex = -1;
    let nearestMainDistance = Number.MAX_SAFE_INTEGER;

    for (let i = 0; i < mainParagraphs.length; i++) {
      const mainIndex = htmlContent.indexOf(mainParagraphs[i].text);
      const distance = subMatch.index - mainIndex;
      if (distance >= 0 && distance < nearestMainDistance) {
        nearestMainIndex = i;
        nearestMainDistance = distance;
      }
    }

    if (nearestMainIndex !== -1) {
      subparagraphs.push({
        id: subId,
        mainId: mainParagraphs[nearestMainIndex].id,
        text: decodeHtmlEntities(subMatch[1]),
      });
    }
  }

  return { mainParagraphs, subparagraphs };
}

export function replaceImageRefs(
  htmlContent: string,
  images?: { name?: string; fileName?: string; dataURL?: string }[]
): string {
  if (!htmlContent || !images?.length) return htmlContent;

  return htmlContent.replace(/src="([^"]+)"/g, (match, imageRef) => {
    const image = images.find(i => i.name === imageRef || i.fileName === imageRef);
    return image?.dataURL ? `src="${image.dataURL}"` : match;
  });
}

export function addHeadingIds(htmlContent: string): string {
  if (!htmlContent) return htmlContent;

  let parCounter = 0;
  let subParCounter = 0;

  return htmlContent
    .replace(/<h2>\s*<\/h2>/g, '')
    .replace(/<h3>\s*<\/h3>/g, '')
    .replace(/<h2>/g, () => `<h2 id="main-${++parCounter}">`)
    .replace(/<h3>/g, () => `<h3 id="sub-${++subParCounter}">`);
}

interface Paragraph { title: string; content: string; paragraphImage?: string; paragraphImageText?: string }

export function buildContentFromParagraphs(paragraphs: Paragraph[]): string {
  if (!paragraphs || paragraphs.length === 0) return '';
  return paragraphs.map(p => {
    let html = `<h2>${p.title}</h2>\n<p>${p.content}</p>`;
    if (p.paragraphImage) {
      html += `\n<div class="thumbnail right">
  <div class="thumbnail-inner">
    <img class="paragraph-image" src="${p.paragraphImage}" alt="logo">
  </div>
  <div class="wikipage-content-container">
    <div>${p.paragraphImageText || ''}</div>
  </div>
</div>`;
    }
    return html;
  }).join('\n');
}

export function processArticleContent(
  htmlContent: string,
  images?: { name?: string; fileName?: string; dataURL?: string }[]
): string {
  if (!htmlContent) return '';

  let content = replaceImageRefs(htmlContent, images);
  content = content.replace(/&lt;/g, '<').replace(/&gt;/g, '>');
  content = addHeadingIds(content);

  content = content.replace(
    /(<h2[^>]*>[\s\S]*?)(?=<h2[^>]*>|$)/g,
    '<div style="display: flow-root;">$1</div>'
  );

  return content;
}
