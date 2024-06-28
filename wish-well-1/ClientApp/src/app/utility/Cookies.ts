export function SetCookie(name: string, value: string): void {
  let expires = "";


  const date = new Date();
  date.setTime(date.getTime() + (1 * 24 * 60 * 60 * 1000));
  expires = "; expires=" + date.toUTCString();

  document.cookie = name + "=" + value + expires + "; path=/";
}

export function GetCookie(name: string): string | null {
  const nameEQ = name + "=";
  const ca = document.cookie.split(';');
  for (let i = 0; i < ca.length; i++) {
    let c = ca[i].trim();
    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
  }
  return null;
}
