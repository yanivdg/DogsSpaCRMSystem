import Image from "next/image";
import Link from 'next/link'
import styles from "./styles/page.module.css";

export default function Home() {
  return (
    <main className={styles.main}>
      <div className={styles.description} >
      </div>
      <div className={styles.center}>
        <Image
          className={styles.logo}
          src="/next.svg"
          alt="Next.js Logo"
          width={180}
          height={37}
          priority
        />
        
      </div>
      <div><a>Welcome to the best Dog's barber shop</a></div>
	  <a 
    href="/pages/signin" 
    className="group rounded-lg border border-transparent px-5 py-4 transition-colors hover:border-gray-300 hover:bg-gray-100 hover:dark:border-neutral-700 hover:dark:bg-neutral-800/30"
          target="_blank"
          rel="noopener noreferrer">
          <h2 className="mb-3 text-2xl font-semibold">
            Sign-In{" "}
            <span className="inline-block transition-transform group-hover:translate-x-1 motion-reduce:transform-none">
              -&gt;
            </span>
          </h2>
          <p className="m-0 max-w-[30ch] text-sm opacity-50">
          Don't Have an Account, Please go for Sign-Up.
          </p>
        </a>
        <a
          href="/pages/signup"
          className="group rounded-lg border border-transparent px-5 py-4 transition-colors hover:border-gray-300 hover:bg-gray-100 hover:dark:border-neutral-700 hover:dark:bg-neutral-800/30"
          target="_blank"
          rel="noopener noreferrer"
        >
          <h2 className="mb-3 text-2xl font-semibold">
            Sign-Up
            <span className="inline-block transition-transform group-hover:translate-x-1 motion-reduce:transform-none">
            </span>
          </h2>
          <p className="m-0 max-w-[30ch] text-sm opacity-50">
                          {"@@@@@@@@@@@@@@@@@@@@@"}
          </p>
        </a>
      <div title="Set Appointment before its too late">
        <Image
          className={styles.logo}
          src="/welcome.jpg"
          alt="welcome picture"
          width={700}
          height={300}
          priority
        />
      </div>
    </main>
  );
}
