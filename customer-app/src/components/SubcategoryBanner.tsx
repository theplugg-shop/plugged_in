import { useNavigate, useSearchParams } from 'react-router-dom'
import { cn } from '@/lib/cn'

export function SubcategoryBanner({
  subcategories,
}: {
  subcategories: { slug: string; name: string }[]
}) {
  const navigate = useNavigate()
  const [searchParams] = useSearchParams()
  const selected = searchParams.get('sub')
  const cat = searchParams.get('cat')

  const go = (sub: string | null) => {
    const params = new URLSearchParams()
    if (cat) params.set('cat', cat)
    if (sub) params.set('sub', sub)
    navigate(params.toString() ? `/?${params.toString()}` : '/')
  }

  return (
    <div className="-mx-4 overflow-x-auto scrollbar-hide bg-ink px-4 py-3 sm:-mx-6 sm:px-6 lg:-mx-8 lg:px-8">
      <div className="flex min-w-max justify-between gap-8 md:min-w-0">
        <button
          onClick={() => go(null)}
          className={cn('shrink-0 text-xs font-bold text-bg/60 hover:text-bg', !selected && 'text-bg')}
        >
          All
        </button>
        {subcategories.map(({ slug, name }) => (
          <button
            key={slug}
            onClick={() => go(slug)}
            className={cn(
              'shrink-0 text-xs font-bold text-bg/60 hover:text-bg',
              selected === slug && 'text-bg',
            )}
          >
            {name}
          </button>
        ))}
      </div>
    </div>
  )
}
