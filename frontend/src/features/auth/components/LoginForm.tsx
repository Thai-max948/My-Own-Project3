import { FormEvent, useId, useState } from 'react';

export function LoginForm() {
  const emailId = useId();
  const passwordId = useId();
  const statusId = useId();
  const [showPassword, setShowPassword] = useState(false);
  const [isUnavailable, setIsUnavailable] = useState(false);

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setIsUnavailable(true);
  }

  return (
    <div className="rounded-3xl border border-white/10 bg-slate-900/80 p-7 shadow-2xl shadow-black/30 backdrop-blur sm:p-10">
      <p className="text-sm font-semibold text-lime-400">Welcome back</p>
      <h2 id="login-heading" className="mt-2 text-3xl font-black tracking-tight">
        Sign in to RepFlow
      </h2>
      <p className="mt-3 text-sm leading-6 text-slate-400">
        Continue your training journey and pick up where you left off.
      </p>

      <form className="mt-8 space-y-5" onSubmit={handleSubmit}>
        <div>
          <label className="mb-2 block text-sm font-semibold text-slate-200" htmlFor={emailId}>
            Email address
          </label>
          <input
            autoComplete="email"
            className="w-full rounded-xl border border-slate-700 bg-slate-950/70 px-4 py-3.5 text-white outline-none transition placeholder:text-slate-600 focus:border-lime-400 focus:ring-4 focus:ring-lime-400/10"
            id={emailId}
            name="email"
            placeholder="you@example.com"
            required
            type="email"
          />
        </div>

        <div>
          <div className="mb-2 flex items-center justify-between">
            <label className="text-sm font-semibold text-slate-200" htmlFor={passwordId}>
              Password
            </label>
            <button
              className="text-xs font-semibold text-slate-400 transition hover:text-lime-400 focus-visible:outline-2 focus-visible:outline-offset-4 focus-visible:outline-lime-400"
              onClick={() => setShowPassword((current) => !current)}
              type="button"
            >
              {showPassword ? 'Hide password' : 'Show password'}
            </button>
          </div>
          <input
            aria-describedby={isUnavailable ? statusId : undefined}
            autoComplete="current-password"
            className="w-full rounded-xl border border-slate-700 bg-slate-950/70 px-4 py-3.5 text-white outline-none transition placeholder:text-slate-600 focus:border-lime-400 focus:ring-4 focus:ring-lime-400/10"
            id={passwordId}
            minLength={8}
            name="password"
            placeholder="Enter your password"
            required
            type={showPassword ? 'text' : 'password'}
          />
        </div>

        {isUnavailable && (
          <p
            className="rounded-xl border border-amber-400/20 bg-amber-400/10 px-4 py-3 text-sm text-amber-200"
            id={statusId}
            role="status"
          >
            Sign-in is not connected yet. The authentication API will be added later.
          </p>
        )}

        <button
          className="w-full rounded-xl bg-lime-400 px-4 py-3.5 text-sm font-black uppercase tracking-[0.16em] text-slate-950 transition hover:bg-lime-300 focus-visible:outline-2 focus-visible:outline-offset-4 focus-visible:outline-lime-400 active:translate-y-px"
          type="submit"
        >
          Sign in
        </button>
      </form>
    </div>
  );
}
