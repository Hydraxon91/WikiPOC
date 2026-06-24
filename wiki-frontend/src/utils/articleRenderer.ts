export interface ParagraphTitles {
  mainParagraphs: { id: string; text: string }[];
  subparagraphs: { id: string; mainId: string; text: string }[];
}

export function extractParagraphTitles(htmlContent: string): ParagraphTitles {
  const mainRegex = /<h2>(.*?)<\/h2>/g;
  const subRegex = /<h3>(.*?)<\/h3>/g;
  const mainParagraphs: { id: string; text: string }[] = [];
  const subparagraphs: { id: string; mainId: string; text: string }[] = [];

  let mainMatch;
  while ((mainMatch = mainRegex.exec(htmlContent)) !== null) {
    const id = `main-${mainParagraphs.length + 1}`;
    mainParagraphs.push({ id, text: mainMatch[1] });
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
        text: subMatch[1],
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

export function renderThumbnails(
  htmlContent: string,
  bodyColor?: string,
  articleRightColor?: string,
  articleRightInnerColor?: string,
  images?: { name?: string; fileName?: string; dataURL?: string }[]
): string {
  if (!htmlContent) return htmlContent;

  const thumbRegex = /<div\s+data-thumb\s+data-orientation="([^"]*)"\s+data-image="([^"]*)"[^>]*>([\s\S]*?)<\/div>/g;

  return htmlContent.replace(thumbRegex, (match, orientation, imageRef, innerHtml) => {
    const image = images?.find(i => i.name === imageRef || i.fileName === imageRef);
    if (!image?.dataURL) return match;

    return `<div class="thumbnail ${orientation}" style="background-color: ${articleRightColor || '#3c5fb8'};">
      <div class="thumbnail-inner" style="background-color: ${articleRightInnerColor || '#2b4ea6'};">
        <img class="paragraphImage" src="${image.dataURL}" alt="Thumbnail"/>
      </div>
      <div class="wikipage-content-container">${innerHtml}</div>
    </div>`;
  });
}

export function addHeadingIds(htmlContent: string): string {
  if (!htmlContent) return htmlContent;

  let parCounter = 0;
  let subParCounter = 0;

  return htmlContent
    .replace(/<h2>/g, () => `<h2 id="main-${++parCounter}">`)
    .replace(/<h3>/g, () => `<h3 id="sub-${++subParCounter}">`);
}

export function processArticleContent(
  htmlContent: string,
  styles?: {
    bodyColor?: string;
    articleColor?: string;
    articleRightColor?: string;
    articleRightInnerColor?: string;
  },
  images?: { name?: string; fileName?: string; dataURL?: string }[]
): string {
  if (!htmlContent) return '';

  let content = replaceImageRefs(htmlContent, images);
  content = content.replace(/&lt;/g, '<').replace(/&gt;/g, '>');
  content = renderThumbnails(content, styles?.bodyColor, styles?.articleRightColor, styles?.articleRightInnerColor, images);
  content = addHeadingIds(content);

  return content;
}
