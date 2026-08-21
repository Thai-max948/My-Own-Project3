import { LoginForm } from './features/auth/components/LoginForm';

export function App() {
  return (
    <main className="relative min-h-screen overflow-hidden bg-slate-950 text-slate-100">
      <div
        aria-hidden="true"
        className="absolute inset-0 bg-[radial-gradient(circle_at_top_left,rgba(163,230,53,0.13),transparent_36%),radial-gradient(circle_at_bottom_right,rgba(14,165,233,0.08),transparent_32%)]"
      />
      <div className="relative mx-auto grid min-h-screen max-w-6xl items-center gap-16 px-6 py-12 lg:grid-cols-2 lg:px-12">
        <section className="hidden lg:block" aria-labelledby="journey-heading">
          <p className="text-sm font-bold uppercase tracking-[0.32em] text-lime-400">
            Workout / Progress / Adaptation
          </p>
          <h1 id="journey-heading" className="mt-6 text-7xl font-black leading-[0.95] tracking-[-0.05em]">
            Build strength.
            <span className="mt-2 block text-slate-500">Keep the streak.</span>
          </h1>
          <p className="mt-8 max-w-lg text-lg leading-8 text-slate-400">
            Your 30-day journey keeps every session, milestone, and next step in one place.
          </p>
        </section>
        <section className="mx-auto w-full max-w-md" aria-labelledby="login-heading">
          <p className="mb-8 text-sm font-bold uppercase tracking-[0.32em] text-lime-400 lg:hidden">RepFlow</p>
          <LoginForm />
        </section>
      </div>
    </main>
  );
}

