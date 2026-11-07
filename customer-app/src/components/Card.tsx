import type { HTMLAttributes } from 'react'
import { cn } from '@/lib/cn'

export function Card({ className, ...props }: HTMLAttributes<HTMLDivElement>) {
  return (
    <div
      className={cn('relative rounded-card border border-line bg-surface p-2.5', className)}
      {...props}
    />
  )
}
