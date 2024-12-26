import Link from "next/link";
import axios from "axios";

export default function Post({ post, categoryId }) {
    if (!post) {
        return (
            <div>
                <h1>Post not found</h1>
                <Link href={`/category/${categoryId}`}>Go back to Category</Link>
            </div>
        );
    }

    return (
        <>
            <h1>{post.title}</h1>
            <p>{post.content || "This is the post content."}</p>
            <Link href={`/category/${categoryId}`}>Back to Category</Link>
        </>
    );
}

export async function getServerSideProps(context) {
    const { postId, categoryId } = context.params;

    try {
        const categoryResponse = await axios.get(
            `http://localhost:3000/categories/${categoryId}`
        );

        if (!categoryResponse.data) {
            return { notFound: true };
        }

        const post = categoryResponse.data.posts.find(post => post.id === postId);
        if (!post) {
            return { notFound: true };
        }

        return {
            props: {
                post,
                categoryId,
            },
        };
        
    } catch (error) {
        console.error("Error fetching post:", error);
        return {
            props: {
                post: null,
                categoryId,
            },
        };
    }
}
