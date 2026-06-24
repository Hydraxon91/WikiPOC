import { format } from 'date-fns';

export function formatDate(dateString: string): string {
  const utcDate = new Date(dateString + 'Z');
  const formatted = format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');
  return formatted.replace(/\//g, '-');
}
