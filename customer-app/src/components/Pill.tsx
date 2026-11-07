import type { HTMLAttributes } from 'react'
import { cn } from '@/lib/cn'

export function Pill({ className, ...props }: HTMLAttributes<HTMLDivElement>) {
  return (
    <div
      className={cn(
        'inline-flex items-center gap-1.5 whitespace-nowrap rounded-pill bg-surface px-3.5 py-2.25 text-xs font-bold',
        className,
      )}
      {...props}
    />
  )
}
