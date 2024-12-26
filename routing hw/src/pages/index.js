import Link from 'next/link';
import { blogData } from '../data/mockdata';

export default function Home() {
  return (
    <div>
      <h1>Blog Categories</h1>
      <ul>
        {blogData.categories.map((category) => (
          <li key={category.id}>
            <Link href={`/category/${category.id}`}>
              {category.name}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}
