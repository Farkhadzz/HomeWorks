import axios from "axios";
import Link from "next/link";

export default function Category({ category }) {
    if (!category) {
        return (
            <div>
                <h1>Category not found</h1>
                <Link href="/">Go back to Home</Link>
            </div>
        );
    }

    return (
        <>
            <h1>Category: {category.name}</h1>
            <h2>Posts</h2>
            <ul>
                {category.posts.map((post) => (
                    <li key={post.id}>
                        <Link href={`/category/${category.id}/post/${post.id}`}>
                            {post.title}
                        </Link>
                    </li>
                ))}
            </ul>
        </>
    );
}

export async function getStaticPaths() {
    const response = await axios.get("http://localhost:3000/categories");
    const categories = response.data;

    const paths = categories.map((category) => ({
        params: { categoryId: category.id },
    }));

    return {
        paths,
        fallback: false,
    };
}

export async function getStaticProps({ params }) {
    const { categoryId } = params;

    const response = await axios.get(`http://localhost:3000/categories/${categoryId}`);
    const category = response.data;

    return {
        props: {
            category,
        },
    };
}
