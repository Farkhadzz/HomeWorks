import { Html, Head, Main, NextScript } from "next/document";
import Link from "next/link";

export default function Document() {
  return (
    <Html lang="en">
      <Head />
      <body>
        <nav style={{ padding: "10px", backgroundColor: "#f0f0f0", display: "flex", gap: "15px" }}>
          <Link href="/" style={{ textDecoration: "none", color: "#0070f3" }}>Home</Link>
          <Link href="/cars" style={{ textDecoration: "none", color: "#0070f3" }}>Cars</Link>
          <Link href="/cars/add" style={{ textDecoration: "none", color: "#0070f3" }}>Add a new car</Link>
        </nav>
        <Main />
        <NextScript />
      </body>
    </Html>
  );
}
