import Quill from 'quill';

const BlockEmbed = Quill.import('blots/block/embed') as any;

class ThumbnailBlot extends BlockEmbed {
  static blotName = 'thumbnail';
  static tagName = 'div';
  static className = 'thumbnail';

  static create(value: string) {
    const node = super.create();
    const data = JSON.parse(value);
    node.className = `thumbnail ${data.orientation}`;
    node.innerHTML = data.content;
    return node;
  }

  static value(node: HTMLElement) {
    const classes = node.className.split(' ');
    const orientation = classes.find(c => c !== 'thumbnail') || 'mid';
    return JSON.stringify({ orientation, content: node.innerHTML });
  }
}

export default ThumbnailBlot;
