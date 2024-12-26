import Link from "next/link";
import axios from "axios";
export default function Home({categories}) {
    return (
        <>
            <h1>All Categories:</h1>
            <ul>
                {categories.map((category) => (
                    <li key={category.id}>
                        <Link href={`/category/${category.id}`}>
                            {category.name}
                        </Link>
                    </li>
                ))}
            </ul>
        </>
    );
}

export async function getStaticProps() {
    const response = await axios.get(`http://localhost:3000/categories`)
    const categories = response.data;
    console.log(categories);
    return {
        props: {
            categories
        },
    };
}