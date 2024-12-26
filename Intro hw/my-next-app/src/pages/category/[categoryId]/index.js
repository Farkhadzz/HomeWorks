import { useRouter } from 'next/router';
import Link from 'next/link';
import { blogData } from '../../../data/mockdata';

export default function Category() {
  const router = useRouter();
  const { categoryId } = router.query;
  
  const category = blogData.categories.find(cat => cat.id === categoryId);
  
  if (!category) {
    return <div>Category not found</div>;
  }

  return (
    <div>
      <h1>{category.name}</h1>
      <ul>
        {category.posts.map((post) => (
          <li key={post.id}>
            <Link href={`/category/${categoryId}/post/${post.id}`}>
              {post.title}
            </Link>
          </li>
        ))}
      </ul>
      <Link href="/">Back to Home</Link>
    </div>
  );
}
