import { useRouter } from 'next/router';
import Link from 'next/link';
import { blogData } from '/data/mockData';

export default function Post() {
  const router = useRouter();
  const { categoryId, postId } = router.query;
  
  const category = blogData.categories.find(cat => cat.id === categoryId);
  const post = category?.posts.find(p => p.id === postId);
  
  if (!post) {
    return <div>Post not found</div>;
  }

  return (
    <div>
      <h1>{post.title}</h1>
      <p>{post.content}</p>
      <Link href={`/category/${categoryId}`}>
        Back to {category.name}
      </Link>
    </div>
  );
}
