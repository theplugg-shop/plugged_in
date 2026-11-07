import { ArrowLeft, Check } from 'lucide-react'
import { useNavigate, useParams } from 'react-router-dom'
import { Pill } from '@/components/Pill'
import { cn } from '@/lib/cn'

const stages = ['Order Packed', 'Picked Up', 'In Transit', 'Delivered'] as const

export default function OrderTrackingPage() {
  const { orderId } = useParams()
  const navigate = useNavigate()

  // No live courier feed wired up yet — this is a static placeholder at the
  // "In Transit" stage so the tracking UI itself can be built and reviewed.
  const currentStageIndex = 2

  return (
    <div className="mx-auto max-w-2xl px-4 pt-5 pb-10 sm:px-6 md:pt-8">
      <div className="flex items-center gap-3">
        <button onClick={() => navigate(-1)} aria-label="Back" className="md:hidden">
          <ArrowLeft size={20} />
        </button>
        <div className="text-lg font-extrabold md:text-2xl">Live Order Tracking</div>
      </div>

      <div className="mt-1 text-xs font-semibold text-muted">Order #{orderId}</div>

      <div className="mt-5 flex items-center justify-between rounded-card bg-surface-2 px-4 py-3">
        <div>
          <div className="text-xs font-bold">{stages[currentStageIndex]}</div>
          <div className="text-[10px] font-semibold text-muted">Est. 09:58 AM</div>
        </div>
        <Pill className="bg-ink text-bg">ETA 12 min</Pill>
      </div>

      <div className="mt-6 space-y-5">
        {stages.map((stage, index) => {
          const done = index <= currentStageIndex
          return (
            <div key={stage} className="flex items-start gap-3">
              <div
                className={cn(
                  'flex h-6 w-6 shrink-0 items-center justify-center rounded-full border-2',
                  done ? 'border-delivered bg-delivered text-white' : 'border-line text-muted',
                )}
              >
                {done && <Check size={13} strokeWidth={3} />}
              </div>
              <div
                className={cn(
                  'text-sm font-bold',
                  done ? 'text-ink' : 'text-muted',
                )}
              >
                {stage}
              </div>
            </div>
          )
        })}
      </div>
    </div>
  )
}
