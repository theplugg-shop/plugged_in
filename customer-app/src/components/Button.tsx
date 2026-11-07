import type { ButtonHTMLAttributes } from 'react'
import { cn } from '@/lib/cn'

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'ink' | 'volt' | 'muted'
}

export function Button({ variant = 'ink', className, ...props }: ButtonProps) {
  return (
    <button
      className={cn(
        'flex items-center justify-center gap-2 rounded-btn px-5.5 py-3.25 text-[12.5px] font-extrabold tracking-[0.02em] transition-opacity active:opacity-80 disabled:opacity-40',
        variant === 'ink' && 'bg-ink text-bg',
        variant === 'volt' && 'bg-volt text-volt-ink',
        variant === 'muted' && 'bg-surface-2 text-muted',
        className,
      )}
      {...props}
    />
  )
}
