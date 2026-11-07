import type { ReactNode } from 'react'

export function Carousel({ title, children }: { title?: string; children: ReactNode }) {
  return (
    <div>
      {title && <div className="mb-3 text-base font-extrabold md:text-lg">{title}</div>}
      <div className="scrollbar-hide flex gap-3 overflow-x-auto pb-1">{children}</div>
    </div>
  )
}
