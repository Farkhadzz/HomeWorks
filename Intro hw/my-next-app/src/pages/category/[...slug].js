import { useRouter } from 'next/router';
import Link from 'next/link';

export default function CatchAll() {
  const router = useRouter();

  return (
    <div>
      <h1>Page Not Found</h1>
      <p>The requested page does not exist.</p>
      <Link href="/">
        Go back to Home
      </Link>
    </div>
  );
}
